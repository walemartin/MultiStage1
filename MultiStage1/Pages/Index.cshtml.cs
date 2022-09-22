using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace MultiStage1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://multiapi/api/Jokes");
                var response = await client.SendAsync(request);
                var joke = await response.Content.ReadAsStringAsync();

                var details = JObject.Parse(joke);
                ViewData["Joke"] = details["name"] + ";;" + details["text"] + ";;" + details["category"];
            }
        }
    }
}