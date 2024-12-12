//using Microsoft.AspNetCore.Builder;

//namespace QuaverEd_App.Server.Github_Api
//{
//    public class GithubApi
//    {
//        public static void Map(WebApplication app)
//        {
//            var apiUrl = "https://api.github.com";

//            //get 100 most starred public repo's
//            app.MapGet() => {
//                using var client = new HttpClient();
//                var response = await client.GetAsync($"{apiUrl}/search/repositories?q=public&sort=stars&order=desc");

//                if (response.IsSuccessStatusCode) {
//                    var json = await response.Content.ReadAsStringAsync();
//                    var gitResponse = JsonConvert.DeserializeObject<ExtCocktailResponse>(json);

//                    if (gitResponse != null)
//                    {
//                        var cocktailDto = CocktailDto.FromCocktailResponse(cocktailResponse);
//                        return Results.Ok(cocktailDto);
//                    }
//                    return Results.NotFound("no cocktails found");
//                }

//                return Results.StatusCode((int)response.StatusCode);
//            }
//        }
//    }
//}
