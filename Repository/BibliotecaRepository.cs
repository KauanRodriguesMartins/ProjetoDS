using ProjetoDS.Data;
using ProjetoDS.Models;

namespace ProjetoDS.Repository
{
    public class BibliotecaRepository : IBibliotecaRepository
    {

        private readonly BibliotecaContext biblioteca_context;
        
        public BibliotecaRepository(BibliotecaContext bibliotecaContext)
        {
            biblioteca_context = bibliotecaContext;
        }
        public List<LivroModel> ListarLivros()
        {
            return biblioteca_context.Livros.ToList();
        }
    }
}