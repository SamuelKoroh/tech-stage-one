using System;
using System.Threading.Tasks;

namespace Author
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ArticleRequest.GotoPage(1);
            var usernames = ArticleRequest.GetUsernames(32);
            var usernamesSortedByRecordDate = ArticleRequest.GetUsernamesSortedByRecordDate(32);

            Console.WriteLine("The author with the highest comment count. .................................................");
            Console.WriteLine(ArticleRequest.GetUsernameWithHighestCommentCount());

            Console.WriteLine();
            Console.WriteLine("The list of most active authors according to a set threshold .........................................................");
            foreach (var username in usernames)
                Console.WriteLine(username);

            Console.WriteLine();
            Console.WriteLine("The list of the authors sorted by when their record was created according to a set threshold ..........................");
            foreach (var username in usernamesSortedByRecordDate)
                Console.WriteLine(username);
        }
    }
}
