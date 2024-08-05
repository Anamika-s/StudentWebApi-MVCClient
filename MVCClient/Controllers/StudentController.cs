using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentWebApi.Models;
using System.Net.Http.Headers;

namespace MVCClient.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                List<Student> students = new List<Student>();
                HttpResponseMessage response = await client.GetAsync("api/student");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    students = JsonConvert.DeserializeObject<List<Student>>(jsonString.Result);


                    return View(students);
                }
                else
                {
                    ViewBag.msg = "No data";
                    return View();
                }

            }
     }

             // GET: StudentController/Details/5
            public async Task<ActionResult> Details(int id)
        {
             Student student = new Student();
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
               
                HttpResponseMessage response = await client.GetAsync("api/student/"+id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                    return View(student);
                }
                else
                {
                    ViewBag.msg = "No data";
                    return View();
                }

            }
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {

            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/student", student);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                }
            }
                
                return RedirectToAction("Index");


            }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = new Student();
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method

                HttpResponseMessage response = await client.GetAsync("api/student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                    return View(student);
                }
                else
                {
                    ViewBag.msg = "No data";
                    return View();
                }
            }
        }
            // POST: StudentController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            Student obj = new Student();
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.PutAsJsonAsync("api/student/"+id, student);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var boolean = JsonConvert.DeserializeObject<bool>(jsonString.Result);


                }
            }

            return RedirectToAction("Index");



        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Student student = new Student();
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method

                HttpResponseMessage response = await client.GetAsync("api/student/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                    return View(student);
                }
                else
                {
                    ViewBag.msg = "No data";
                    return View();
                }
            }
        }
                // POST: StudentController/Delete/5
                [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Student student)
        {
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here. 
                client.BaseAddress = new Uri("https://localhost:7008/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.DeleteAsync("api/student/"+id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var boolean = JsonConvert.DeserializeObject<bool>(jsonString.Result);


                }
            }

            return RedirectToAction("Index");




        }
    }
}
