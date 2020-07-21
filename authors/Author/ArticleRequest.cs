using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Author
{
    public class ArticleRequest
    {
        private static string _url = "https://jsonmock.hackerrank.com/api/article_users/search?page=";
        private static Article _article;
        private static readonly HttpClient _client;

        static ArticleRequest()
        {
            _client = new HttpClient();
        }
        public static async Task GotoPage(int page = 1)
        {
            _url += page;

            var response = await _client.GetAsync(new Uri(_url));
            var content = await response.Content.ReadAsStringAsync();

            _article = JsonConvert.DeserializeObject<Article>(content);
        }
        public static List<string> GetUsernames(int threshold)
        {
            return _article.data.Where(x => x.submission_count >= threshold)
                .Select(x => x.username).ToList();
        }

        public static string GetUsernameWithHighestCommentCount()
        {
            return _article.data.OrderByDescending(x => x.comment_count)
                .Select(x => x.username).FirstOrDefault();
        }

        public static List<string> GetUsernamesSortedByRecordDate(int threshold)
        {
            return _article.data.Where(x => x.submission_count >= threshold)
                .OrderBy(x => x.created_at)
                .Select(x => x.username)
                .ToList();
        }
    }
}
