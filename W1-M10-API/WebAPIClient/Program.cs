using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
namespace WebAPIClient
{
    class Program

    {
        /// <summary> 
        /// Creates a new HttpClient called client
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            /// <summary> 
            /// Wait until repository is processed
            /// </summary>
            var repositories = await ProcessRepositories();
            /// <summary> 
            /// Loop through each repository
            /// </summary>
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine();
            }
        }

        /// <summary> 
        /// List of Repositorys that are processed
        /// </summary>
        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".Net Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            return repositories;


            foreach (var repo in repositories)
                Console.WriteLine(repo.Name);

        }
        
    }
}
