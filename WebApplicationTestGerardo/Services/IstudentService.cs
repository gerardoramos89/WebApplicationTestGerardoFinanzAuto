using Microsoft.AspNetCore.Mvc;
using WebApplicationTestGerardo.Domain;

namespace WebApplicationTestGerardo.Services
{
    public interface IstudentService
    {
        Task<IEnumerable<students>> GetEstudiantesAsync();
        Task<students> GetStudentByIdentificationAsync(string identification);
        Task AddStudentAsync(students student);
        Task UpdateStudentAsync(students student);
        Task DeleteStudentAsync(string identification);

        // Métodos para paginación
        Task<int> GetTotalEstudiantesAsync(); // Contar total de estudiantes
        Task<IEnumerable<students>> GetEstudiantesPaginatedAsync(int pageNumber, int pageSize); // Obtener estudiantes paginados
    }
}
