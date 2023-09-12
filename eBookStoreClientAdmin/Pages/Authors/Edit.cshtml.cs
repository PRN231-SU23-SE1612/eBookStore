using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Repositories;
using AutoMapper;
using System.Net.Http.Headers;
using System.Text.Json;
using BusinessObjects.DTO;
using System.Text;

namespace eBookStoreClientAdmin.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        private IMapper mapper;
        public EditModel(IMapper _mapper)
        {
            this.mapper = _mapper;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Author";
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            HttpResponseMessage respone = await client.GetAsync($"{BaseUrl}/{id}");
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Author = JsonSerializer.Deserialize<Author>(strData, options);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
                    HttpResponseMessage response = await client.PutAsync($"{BaseUrl}/Update/{Author.AuthorId}", content);
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
