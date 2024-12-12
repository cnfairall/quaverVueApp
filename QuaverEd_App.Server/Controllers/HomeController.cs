using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuaverEd_App.Server.Models;

namespace QuaverEd_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {


        [HttpGet(Name = "getGithub")]
        public async Task<object> GetAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.github.com/search/repositories?q=public&sort=stars&order=desc");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var gitResponse = JsonConvert.DeserializeObject<GithubResponse>(json);

                if (gitResponse != null)
                {
                    var repo = RepoDto.FromGithubResponse(gitResponse);
                    return Results.Ok(repo);
                }
                return Results.NotFound("no cocktails found");
            }

            return Results.StatusCode((int)response.StatusCode);
        }

    }
}
