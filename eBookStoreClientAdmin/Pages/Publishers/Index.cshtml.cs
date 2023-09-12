using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStoreClientAdmin.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        public IList<Publisher> Publisher { get; set; } = default!;

        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Publisher";
        }

        public async Task OnGetAsync()
        {
            HttpResponseMessage respone = await client.GetAsync(BaseUrl);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Publisher = (IList<Publisher>)JsonSerializer.Deserialize<List<Publisher>>(strData, options);
        }
    }
}
