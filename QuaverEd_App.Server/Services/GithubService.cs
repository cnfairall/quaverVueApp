using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuaverEd_App.Data;
using QuaverEd_App.Server.Models;

namespace QuaverEd_App.Server.Services
{
    public class GithubService : IGithubService
    {

        private readonly QuaverEd_AppDbContext _context;

        public GithubService(QuaverEd_AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RepoDto>> GetGithubData()
        {
            using var client = new HttpClient();
            string apiUrl = "https://api.github.com";
            try
            {

                client.DefaultRequestHeaders.Add("User-Agent", "request");
                var response = await client.GetAsync($"{apiUrl}/search/repositories?q=language:C%23&per_page=100&page=1&sort=stars&order=desc");

                    var json = await response.Content.ReadAsStringAsync();
                    var gitResponse = JsonConvert.DeserializeObject<GithubResponse>(json);

                    if (gitResponse != null)
                    {
                        var repos = RepoDto.FromGithubResponse(gitResponse);
                        return repos;

                    }
                    else
                    {
                        return null;

                    }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
        }
        public async Task<IResult> PostData()
        {
            IEnumerable<RepoDto> fetch = await GetGithubData();
            IEnumerable<Repository> existingRepos = _context.Repository.ToList();
            if (existingRepos != null)
            {
                foreach (var repo in existingRepos)
                {
                    _context.Repository.Remove(repo);
                }
                _context.SaveChanges();
            }

            foreach (var repo in fetch)
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
