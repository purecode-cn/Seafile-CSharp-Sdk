using SeafileClient;
using System;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var seafile = Api.GetApi("https://cloud.seafile.com");
            var accessToken = seafile.Login("« user email »", "« password »");

            var defaultRepo = seafile.GetDefaultRepo(accessToken);

            Console.WriteLine($"Default Repo:\n  - Id: {defaultRepo.Id}\n");

            var repos = seafile.ListRepos(accessToken);

            Console.WriteLine("Repos:");
            foreach (var repo in repos)
            {
                Console.WriteLine($"  - Id: {repo.Id}, Name: {repo.Name}");
            }
        }
    }
}
