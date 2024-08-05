using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        IStudentRepo _repo;
        public StudentController(IStudentRepo repo)
        {
            _repo = repo;

        }
        // GET: api/<StudentController>
        [HttpGet]
        public  ActionResult  Get()
        {
            return Ok(_repo.GetStudents().ToList()); 
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_repo.GetStudent(id));
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Student student)
        {
           return Created("added", _repo.AddStudent(student));
            
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]  Student student)
        {
           return Ok(_repo.UpdateStudent(id, student));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public  ActionResult  Delete(int id)
        {
           return Ok(_repo.DeleteStudent(id));
        }
    }
}
