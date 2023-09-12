using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects;
using System.Net.Http.Headers;
using BusinessObjects.DTO;
using AutoMapper;
using System.Text.Json;
using System.Text;

namespace eBookStoreClientAdmin.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        private IMapper mapper;

        public CreateModel(IMapper _mapper)
        {
            this.mapper = _mapper;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Author";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            AuthorDTO dto = mapper.Map<AuthorDTO>(Author);
            try
            {
                using (var client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    string data = JsonSerializer.Serialize(dto);
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(BaseUrl, content);
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
