using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTestGerardo.Domain;
using WebApplicationTestGerardo.Services;

namespace WebApplicationTestGerardo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IstudentService _estudentService;

        public StudentController(IstudentService estudentService)
        {
            _estudentService = estudentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<students>>> GetEstudiantes()
        {
            var Students = await _estudentService.GetEstudiantesAsync();
            return Ok(Students);
        }


        [HttpGet("{identification}")]
        public async Task<ActionResult<students>> GetStudentByIdentification(string identification)
        {
            // Buscar el estudiante por identificación usando el servicio
            var student = await _estudentService.GetStudentByIdentificationAsync(identification);

            if (student == null)
            {
                return NotFound();  // Si no se encuentra el estudiante
            }

            return Ok(student);  // Si se encuentra, se retorna el estudiante
        }

        [HttpPost]
        public async Task<ActionResult<students>> CreateStudent(students student)
        {
            if (student == null)
            {
                return BadRequest("El estudiante no puede ser nulo.");
            }

            await _estudentService.AddStudentAsync(student);

            return CreatedAtAction(nameof(GetStudentByIdentification), new { identification = student.identification }, student);
        }

        // PUT api/students/{identification}
        [HttpPut("{identification}")]
        public async Task<ActionResult> UpdateStudent(string identification, students student)
        {
            if (identification != student.identification)
            {
                return BadRequest("El identificador no coincide.");
            }

            var existingStudent = await _estudentService.GetStudentByIdentificationAsync(identification);

            if (existingStudent == null)
            {
                return NotFound("Estudiante no encontrado.");
            }

            // Actualizar los campos necesarios
            existingStudent.first_name = student.first_name;
            existingStudent.last_name = student.last_name;
            existingStudent.date_of_birth = student.date_of_birth;
            existingStudent.email = student.email;

            await _estudentService.UpdateStudentAsync(existingStudent);

            return NoContent();  // Devuelve un 204 No Content si la actualización fue exitosa
        }

        // DELETE api/students/{identification}
        [HttpDelete("{identification}")]
        public async Task<ActionResult> DeleteStudent(string identification)
        {
            var student = await _estudentService.GetStudentByIdentificationAsync(identification);

            if (student == null)
            {
                return NotFound("Estudiante no encontrado.");
            }

            await _estudentService.DeleteStudentAsync(identification);

            return NoContent();  // Devuelve un 204 No Content si la eliminación fue exitosa
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedResponse<students>>> GetEstudiantesPaginated(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize <= 0) pageSize = 10;
            if (pageNumber <= 0) pageNumber = 1;

            var totalStudents = await _estudentService.GetTotalEstudiantesAsync();
            var students = await _estudentService.GetEstudiantesPaginatedAsync(pageNumber, pageSize);

            var response = new PaginatedResponse<students>
            {
                Items = students,
                TotalItems = totalStudents,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(response);
        }
    }
}
