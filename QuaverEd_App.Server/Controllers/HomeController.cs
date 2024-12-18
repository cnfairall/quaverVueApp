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
        //access db via dependency injection
        private readonly QuaverEd_AppDbContext _context;

        public HomeController(QuaverEd_AppDbContext context)
        {
            _context = context;
        }

        //get list of top 100 repos
        [HttpGet(Name = "Repos")]
        public IResult Index()
        {
            IEnumerable<ListViewRepo> repos = _context.Repository
                .Select((repo) =>
                new ListViewRepo()
                {
                  Id = repo.Id,
                  RepoName = repo.RepoName,
                  OwnerName = repo.OwnerName,
                  NumStars = repo.NumStars
                });
            if (repos == null)
            {
                return Results.NotFound("No repos found");
            }
            else
            {
                return Results.Ok(repos);
            }
        }

        //get full details of repo by id
        [HttpGet(Name ="Details")]
        public IResult Details(int id)
        {
            Repository repository = _context.Repository
                .FirstOrDefault((repo) => repo.Id == id);
            if (repository != null)
            {
                return Results.Ok(repository);
            }
            return Results.BadRequest("repository not found");
        }
    }

}
