using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuaverEd_App.Server.Models;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.EntityFrameworkCore;
using QuaverEd_App.Data;

namespace QuaverEd_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly QuaverEd_AppDbContext _context;

        public HomeController(QuaverEd_AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "Index")]
        public async Task<object> GetAsync()
        {
            string apiUrl = "https://api.github.com";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            var response = await client.GetAsync($"{apiUrl}/search/repositories?q=language:C%23&per_page=100&page=1&sort=stars&order=desc");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var gitResponse = JsonConvert.DeserializeObject<GithubResponse>(json);

                if (gitResponse != null)
                {
                    var repo = RepoDto.FromGithubResponse(gitResponse);
                    return Results.Ok(repo);
                }
                return Results.NotFound("not found");
            }

            return Results.StatusCode((int)response.StatusCode);
        }

        [HttpPost(Name = "Post")]
        public IResult Post(RepoDto repoObj)
        {
            var existingRepo = _context.Repository.FirstOrDefault((repo) => repo.GithubId == repoObj.GithubId);
            if (existingRepo != null)
            {
                return Results.BadRequest("Repo already in database");
            }
            else
            {
                var newRepo = new Repository()
                {
                    GithubId = repoObj.GithubId,
                    RepoName = repoObj.RepoName,
                    OwnerName = repoObj.OwnerName,
                    RepoUrl = repoObj.RepoUrl,
                    RepoDescription = repoObj.RepoDescription,
                    CreatedDate = repoObj.CreatedDate,
                    LastPushDate = repoObj.LastPushDate,
                    NumStars = repoObj.NumStars,
                };
                _context.Repository.Add(newRepo);
                _context.SaveChanges();
                return Results.Ok(newRepo.Id);

            }
        }

    }

}
