using QuaverEd_App.Server.Models;

namespace QuaverEd_App.Server.Services
{
    public interface IGithubService
    {
        Task<IEnumerable<RepoDto>> GetGithubData();

        Task<IResult> PostData();
    }
}
