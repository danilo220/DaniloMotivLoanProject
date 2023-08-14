using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Models;
using System.Configuration;
using System.Text.Json;

namespace MotivWebApp.Pages
{
    public class RandomUserDetailsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public RandomUserDetailsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public RandomUserDetail UserDetail { get; set; }
        public async Task<IActionResult> OnGet()
        {
            UserDetail = await GetRandomUser();
            if(UserDetail == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
        public async Task<RandomUserDetail> GetRandomUser()
        {
            //string url = _configuration["ConnectionStrings:RandomUserApiUrl"];
            string url = GetEndpointUrl();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage();
                    request.RequestUri = new Uri(url);
                    request.Method = HttpMethod.Get;

                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    var responseString = await responseMessage.Content.ReadAsStringAsync();
                    var statusCode = responseMessage.StatusCode;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        RandomUserDetails userDetails = JsonSerializer.Deserialize<RandomUserDetails>(responseString, options);
                        return userDetails.results.FirstOrDefault();
                    }

                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private string GetEndpointUrl()
        {
            var valuesSection = _configuration.GetSection("ConnectionStringsInternal");
            foreach (IConfigurationSection section in valuesSection.GetChildren())
            {
                string url = section.GetValue<string>("RandomUserApiUrl");
                string environment = section.GetValue<string>("Environment");
                if(String.Equals(environment, "staging"))
                {
                    return url;
                }
            }
            return "";
        }
    }
}
