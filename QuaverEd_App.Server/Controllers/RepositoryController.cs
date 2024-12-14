using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using QuaverEd_App.Data;
using QuaverEd_App.Server.Models;
using System.Data;

namespace QuaverEd_App.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly QuaverEd_AppDbContext _context;

        public RepositoryController(QuaverEd_AppDbContext context)
        {
            _context = context;
        }


        [HttpGet(Name = "Repos")]
        public string Get()
        {
            return "repos";
        }

    }
}
