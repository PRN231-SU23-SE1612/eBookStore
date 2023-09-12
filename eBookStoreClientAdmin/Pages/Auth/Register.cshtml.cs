using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStoreClientAdmin.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        private IMapper mapper;
        [BindProperty]
        public BusinessObjects.Auth.RegisterModel _RegisterModel { get; set; } = default!;

        public RegisterModel(IMapper _mapper)
        {
            this.mapper = _mapper;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:7000/api/Auth";
        }
        public ActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage();
                string data = JsonSerializer.Serialize(_RegisterModel);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}/register", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var statusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {                    
                    return RedirectToPage("./Login");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
