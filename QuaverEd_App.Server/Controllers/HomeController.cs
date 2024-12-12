using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuaverEd_App.Server.Models;
using System.Net.Http.Headers;
using System.Net;
using Octokit;

namespace QuaverEd_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet(Name = "getGithub")]
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

    }
}
