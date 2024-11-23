using WebApplicationTestGerardo.Data;
using WebApplicationTestGerardo.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplicationTestGerardo.Services
{
    public class StudentService :IstudentService
    {
        private readonly EstudentsContext _context;

        public StudentService(EstudentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<students>> GetEstudiantesAsync()
        {
            return await _context.students.ToListAsync();
        }
        public async Task<students> GetStudentByIdentificationAsync(string identification)
        {
            // Asegúrate de que el campo Identification esté indexado y sea único en la base de datos.
            return await _context.students
                                 .FirstOrDefaultAsync(s => s.identification == identification);
        }
        public async Task AddStudentAsync(students student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(students student)
        {
            _context.students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(string identification)
        {
            var student = await GetStudentByIdentificationAsync(identification);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalEstudiantesAsync()
        {
            return await _context.students.CountAsync(); // Ajusta el acceso según tu implementación
        }

        public async Task<IEnumerable<students>> GetEstudiantesPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _context.students
                .OrderBy(s => s.Id) // Cambia "Id" según el campo que uses para ordenar
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
