using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentWebApi.Models;
using System.Net.Http.Headers;
using System.Text;

namespace MVCClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Login(User user)
        {
            string url = "https://localhost:7008/api/Login";
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                var token = string.Empty;
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = "https://localhost:7008/api/Login";
                client.BaseAddress = new Uri(endpoint);
                var contentType = new MediaTypeWithQualityHeaderValue
    ("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var Response = client.PostAsync(endpoint, content);
                var response = Response.Result;
                if (response.IsSuccessStatusCode)
                {
                    var stringJWT = response.Content.ReadAsStringAsync().Result;
                    JWT jwt = JsonConvert.DeserializeObject
      <JWT>(stringJWT);
                    HttpContext.Session.SetString("token", jwt.Token);

                    ViewBag.Message = "User logged in successfully!";
                    //HttpContext.Session["token"] = token.ToString();
                    //return View();

                    return RedirectToAction("Index", "Student");


                }
                else 
                    return View();
                }

            }
        public class JWT
        {
            public string Token { get; set; }
        }

    }
}
