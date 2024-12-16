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
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly QuaverEd_AppDbContext _context;

        public HomeController(QuaverEd_AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "Repos")]
        public IResult Get()
        {
            IEnumerable<Repository> repos = _context.Repository;
            if (repos == null)
            {
                return Results.NotFound("No repos found");
            }
            else
            {
                return Results.Ok(repos);
            }
        }

        //[HttpGet(Name = "Index")]
        //public async Task<object> GetAsync()
        //{
        //    string apiUrl = "https://api.github.com";

        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("User-Agent", "request");
        //    var response = await client.GetAsync($"{apiUrl}/search/repositories?q=language:C%23&per_page=100&page=1&sort=stars&order=desc");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadAsStringAsync();
        //        var gitResponse = JsonConvert.DeserializeObject<GithubResponse>(json);

        //        if (gitResponse != null)
        //        {
        //            var repo = RepoDto.FromGithubResponse(gitResponse);
        //            return Results.Ok(repo);
        //        }
        //        return Results.NotFound("not found");
        //    }

        //    return Results.StatusCode((int)response.StatusCode);
        //}

        [HttpPost(Name = "Post")]
        public IResult Post(IEnumerable<RepoDto> githubRepos)
        {
            IEnumerable<Repository> existingRepos = _context.Repository.ToList();
            if (existingRepos != null)
            {
                foreach (var repo in existingRepos)
                {
                    _context.Repository.Remove(repo);
                }
                _context.SaveChanges();
            }
            
            foreach (var repo in githubRepos)
            {
                var newRepo = new Repository()
                {
                    GithubId = repo.GithubId,
                    RepoName = repo.RepoName,
                    OwnerName = repo.OwnerName,
                    RepoUrl = repo.RepoUrl,
                    RepoDescription = repo.RepoDescription,
                    CreatedDate = repo.CreatedDate,
                    LastPushDate = repo.LastPushDate,
                    NumStars = repo.NumStars
                };

                _context.Repository.Add(newRepo);
            }
            _context.SaveChanges();
            return Results.Ok("repos added"); 

        }

    }

}
