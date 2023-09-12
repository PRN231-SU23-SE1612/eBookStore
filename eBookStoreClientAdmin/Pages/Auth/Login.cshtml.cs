using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Auth;
using AutoMapper;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace eBookStoreClientAdmin.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BaseUrl = "";
        private IMapper mapper;
        [BindProperty]
        public BusinessObjects.Auth.LoginModel _LoginModel { get; set; } = default!;

        public LoginModel(IMapper _mapper)
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
                string data = JsonSerializer.Serialize(_LoginModel);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{BaseUrl}/login", content);                
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync();
                    string token = JObject.Parse(await responseString).GetValue("token").ToString();
                    var statusCode = response.StatusCode;
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("access_token", token, option);
                    return RedirectToPage("../Index");
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
