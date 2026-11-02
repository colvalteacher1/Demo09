using Demo09.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentDao studentDao = new StudentDao();

        //Appel du service : GET /api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(studentDao.Students);
        }

        //Appel du service : GET /api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetOnStudent([FromRoute] int id)
        {
            var student = studentDao.Students.FirstOrDefault(s  => s.Id == id);
            if (student == null)
                return NotFound("Aucun étudiant avec cet id n'est trouvé");
            return Ok(student);
        }
    }
}
