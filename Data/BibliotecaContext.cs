using Microsoft.EntityFrameworkCore;
using ProjetoDS.Models;

namespace ProjetoDS.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
            
        }

        public DbSet<LivroModel> Livros {get; set;}
        public DbSet<UsuarioModel> Usuarios {get; set;}
        public DbSet<EmprestimoModel> Emprestimos {get; set;}
    }
}