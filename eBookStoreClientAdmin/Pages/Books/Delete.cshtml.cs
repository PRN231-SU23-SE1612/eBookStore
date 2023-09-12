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
using BusinessObjects.DTO;

namespace eBookStoreClientAdmin.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        public DeleteModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Book";
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    HttpResponseMessage response = await client.DeleteAsync($"{BaseUrl}/Delete/{Book.BookId}");
                    var responseString = await response.Content.ReadAsStringAsync();
                    var statusCode = response.StatusCode;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToPage("./Index");
                    }

                    else
                    {
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
