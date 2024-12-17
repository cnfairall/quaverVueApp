
namespace QuaverEd_App.Server.Models

{
    public class GithubResponse
    {
        public List<RawRepository> Items { get; set; }
    }

    public class RawRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Private { get; set; }
        public Owner Owner { get; set; }
        public string Html_Url { get; set; }
        public string? Description { get; set; }
        public bool Fork { get; set; }
        public string Url { get; set; }
        public string Forks_Url { get; set; }
        public string Keys_Url { get; set; }
        public string Collaborators_Url { get; set; }
        public string Teams_Url { get; set; }
        public string Hooks_Url { get; set; }
        public string Issue_Events_Url { get; set; }
        public string Events_Url { get; set; }
        public string Assignees_Url { get; set; }
        public string Branches_Url { get; set; }
        public string Tags_Url { get; set; }
        public string Blobs_Url { get; set; }
        public string Git_Tags_Url { get; set; }
        public string Git_Refs_Url { get; set; }
        public string Trees_Url { get; set; }
        public string Statuses_Url { get; set; }
        public string Languages_Url { get; set; }
        public string Stargazers_Url { get; set; }
        public string Contributors_Url { get; set; }
        public string Subscribers_Url { get; set; }
        public string Subscription_Url { get; set; }
        public string Commits_Url { get; set; }
        public string Git_Commits_Url { get; set; }
        public string Comments_Url { get; set; }
        public string Issue_Comment_Url { get; set; }
        public string Contents_Url { get; set; }
        public string Compare_Url { get; set; }
        public string Merges_Url { get; set; }
        public string Archive_Url { get; set; }
        public string Downloads_Url { get; set; }
        public string Issues_Url { get; set; }
        public string Pulls_Url { get; set; }
        public string Milestones_Url { get; set; }
        public string Notifications_Url { get; set; }
        public string Labels_Url { get; set; }
        public string Releases_Url { get; set; }
        public string Deployments_Url { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Pushed_At { get; set; }
        public string Git_Url { get; set; }
        public string Ssh_Url { get; set; }
        public string Clone_Url { get; set; }
        public string Svn_Url { get; set; }
        public string Homepage { get; set; }
        public int Size { get; set; }
        public int Stargazers_Count { get; set; }
        public int Watchers_Count { get; set; }
        public string Language { get; set; }
        public bool Has_Issues { get; set; }
        public bool Has_Projects { get; set; }
        public bool Has_Downloads { get; set; }
        public bool Has_Wiki { get; set; }
        public bool Has_Pages { get; set; }
        public bool Has_Discussions { get; set; }
        public int Forks_Count { get; set; }
        public int Open_Issues_Count { get; set; }
        public License License { get; set; }
        public bool Allow_Forking { get; set; }
        public bool Is_Template { get; set; }
        public bool Web_Commit_Signoff_Required { get; set; }
        public List<string> Topics { get; set; }
        public string Visibility { get; set; }
        public int Forks { get; set; }
        public int Open_Issues { get; set; }
        public int Watchers { get; set; }
        public string Default_Branch { get; set; }
        public float Score { get; set; }

    }

    public class Owner
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Node_Id { get; set; }
        public string Avatar_Url { get; set; }
        public string Gravatar_Id { get; set; }
        public string Url { get; set; }
        public string Html_Url { get; set; }
        public string Followers_Url { get; set; }
        public string Following_Url { get; set; }
        public string Gists_Url { get; set; }
        public string Starred_Url { get; set; }
        public string Subscriptions_Url { get; set; }
        public string Organizations_Url { get; set; }
        public string Repos_Url { get; set; }
        public string Events_Url { get; set; }
        public string Received_Events_Url { get; set; }
        public string Type { get; set; }
        public string User_View_Type { get; set; }
        public bool Site_Admin { get; set; }
    }

    public class License
    {
        public string Key
        {
            get; set;
        }

    }

    public class RepoDto
    {
        public int GithubId { get; set; }
        public string RepoName { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastPushDate { get; set; }
        public string RepoUrl { get; set; }
        public string? RepoDescription { get; set; }
        public int NumStars { get; set; }

        public static IEnumerable<RepoDto> FromGithubResponse(GithubResponse response)
        {
            return response.Items
                .Select(item => new RepoDto
            {
                GithubId = item.Id,
                RepoName = item.Name,
                OwnerName = item.Owner.Login,
                CreatedDate = item.Created_At,
                LastPushDate = item.Pushed_At,
                RepoUrl = item.Html_Url,
                RepoDescription = item.Description,
                NumStars = item.Stargazers_Count,
            });
        }

    }

   
}
