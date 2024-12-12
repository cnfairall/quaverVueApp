using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace QuaverEd_App.Server.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public int GithubId { get; set; }
        public string RepoName { get; set; }
        public string OwnerName { get; set; }
        public string RepoUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastPushDate { get; set; }
        public string RepoDescription { get; set; }
        public int NumStars { get; set; }


    }
}
