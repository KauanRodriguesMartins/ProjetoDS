using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjetoDS.Models;

namespace ProjetoDS.Data
{
    public class BibliotecaContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
    }
}
