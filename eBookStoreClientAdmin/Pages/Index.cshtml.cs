using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace eBookStoreClientAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient client = null;
        private string BaseUrl = "";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/User";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            string token = Request.Cookies["access_token"];
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            HttpResponseMessage respone = await client.GetAsync($"{BaseUrl}/Admin");
            if (respone.IsSuccessStatusCode)
            {
                return Page();
            }else if(respone.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return RedirectToPage("./Auth/Login");
            }
            return Page();
        }
    }
}