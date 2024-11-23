using Microsoft.EntityFrameworkCore;
using WebApplicationTestGerardo.Domain;
using System.Collections.Generic;

namespace WebApplicationTestGerardo.Data
{
    public class EstudentsContext : DbContext
    {
        public EstudentsContext(DbContextOptions<EstudentsContext> options) : base(options) { }

        public DbSet<students> students { get; set; }
    }
}