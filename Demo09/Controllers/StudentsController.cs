using Demo09.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Appel du service : GET /api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(StudentDao.Students);
        }

        //Appel du service : GET /api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetOnStudent([FromRoute] int id)
        {
            var student = StudentDao.Students.FirstOrDefault(s  => s.Id == id);
            if (student == null)
                return NotFound("Aucun étudiant avec cet id n'est trouvé");
            return Ok(student);
        }


        [HttpPost]
        public IActionResult AddNewStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Problème de lecture de données du nouvel étudiant");

            //générer le nouvel id de cet étudian
            int newId = StudentDao.Students.Last().Id + 1;
            student.Id = newId;
            StudentDao.Students.Add(student);
            
            return Created($"GET /api/students/{newId}", student);
        }

    }
}
