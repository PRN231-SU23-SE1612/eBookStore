using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStoreClient.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        public DetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Book";
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{BaseUrl}/{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Book = JsonSerializer.Deserialize<Book>(strData, options);
            return Page();
        }
    }
}
