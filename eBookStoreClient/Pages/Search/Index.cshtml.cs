using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStoreClient.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        public IList<Book> Book { get; set; } = default!;

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Book";
        }

        public async Task<IActionResult> OnGetAsync(string text)
        {
            HttpResponseMessage respone = await client.GetAsync($"{BaseUrl}?$filter=contains(Title,'{text}')");
            string txt = $"{BaseUrl}?$filter=contains(Title,'${text}')";
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Book = JsonSerializer.Deserialize<List<Book>>(strData, options);
            return Page();
        }
    }
}
