using ProjetoDS.Controllers;
using ProjetoDS.Models;

namespace ProjetoDS.Repository
{
    public interface IBibliotecaRepository
    {
        //Comandos para Livro
        List<LivroModel> ListarLivros();
    }
}