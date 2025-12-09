using ProjetoDS.Controllers;
using ProjetoDS.Models;

namespace ProjetoDS.Repository
{
    public interface IBibliotecaRepository
    {
        //Comandos para Livro
        List<LivroModel> ListarLivros();
        LivroModel Adicionar(LivroModel livro);
        LivroModel BuscarId(int Id);
        LivroModel Atualizar(LivroModel livro);
        bool Deletar(int Id);

        //Comandos para Usuario
        List<UsuarioModel> ListarUsuarios();
        UsuarioModel AdicionarUsuario(UsuarioModel usuario);
        UsuarioModel BuscarUsuarioPorId(int Id);
        UsuarioModel AtualizarUsuario(UsuarioModel usuario);
        bool DeletarUsuario(int Id);

        //Comandos para Emprestimo
        List<EmprestimoModel> ListarEmprestimos();
        EmprestimoModel AdicionarEmprestimo(EmprestimoModel emprestimo);
        EmprestimoModel BuscarEmprestimoPorId(int Id);
        EmprestimoModel AtualizarEmprestimo(EmprestimoModel emprestimo);
        bool DeletarEmprestimo(int Id);

    }
}