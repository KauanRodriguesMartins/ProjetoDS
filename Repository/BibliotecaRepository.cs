using ProjetoDS.Data;
using ProjetoDS.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDS.Repository
{
    public class BibliotecaRepository : IBibliotecaRepository
    {

        private readonly BibliotecaContext biblioteca_context;

        public BibliotecaRepository(BibliotecaContext bibliotecaContext)
        {
            biblioteca_context = bibliotecaContext;
        }

        //Comandos para livro

        public LivroModel Adicionar(LivroModel livro)
        {
            biblioteca_context.Livros.Add(livro);
            biblioteca_context.SaveChanges();
            return livro;
        }

        public LivroModel Atualizar(LivroModel livro)
        {
            LivroModel LivroDB = BuscarId(livro.Id);
            if (LivroDB == null) throw new Exception("Livro não foi encontrado");

            LivroDB.Titulo = livro.Titulo;
            LivroDB.Autor = livro.Autor;
            LivroDB.AnoPublicacao = livro.AnoPublicacao;
            LivroDB.Genero = livro.Genero;
            LivroDB.QuantidadeDisponivel = livro.QuantidadeDisponivel;
            LivroDB.Status = livro.Status;

            biblioteca_context.Livros.Update(LivroDB);
            biblioteca_context.SaveChanges();
            return LivroDB;
        }

        public LivroModel BuscarId(int Id)
        {
            return biblioteca_context.Livros.FirstOrDefault(x => x.Id == Id);
        }

        public bool Deletar(int Id)
        {
            LivroModel LivroDB = BuscarId(Id);
            if (LivroDB == null) throw new Exception("Livro não foi encontrado");

            biblioteca_context.Livros.Remove(LivroDB);
            biblioteca_context.SaveChanges();
            return true;
        }

        public List<LivroModel> ListarLivros()
        {
            return biblioteca_context.Livros.ToList();
        }

        //Comandos para Usuario

        public List<UsuarioModel> ListarUsuarios()
        {
            return biblioteca_context.Usuarios.ToList();
        }

        public UsuarioModel AdicionarUsuario(UsuarioModel usuario)
        {
            biblioteca_context.Usuarios.Add(usuario);
            biblioteca_context.SaveChanges();
            return usuario;
        }

        public UsuarioModel BuscarUsuarioPorId(int Id)
        {
            return biblioteca_context.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

        public UsuarioModel AtualizarUsuario(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarUsuarioPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Usuário não encontrado");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.CPF = usuario.CPF;
            usuarioDB.Idade = usuario.Idade;

            biblioteca_context.Usuarios.Update(usuarioDB);
            biblioteca_context.SaveChanges();

            return usuarioDB;
        }

        public bool DeletarUsuario(int Id)
        {
            UsuarioModel usuarioDB = BuscarUsuarioPorId(Id);

            if (usuarioDB == null) throw new Exception("Usuário não encontrado");

            biblioteca_context.Usuarios.Remove(usuarioDB);
            biblioteca_context.SaveChanges();

            return true;
        }

        //Comandos para Emprestimo
        public List<EmprestimoModel> ListarEmprestimos()
        {
            return biblioteca_context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .ToList();
        }

        public EmprestimoModel AdicionarEmprestimo(EmprestimoModel emprestimo)
        {
            biblioteca_context.Emprestimos.Add(emprestimo);
            biblioteca_context.SaveChanges();
            return emprestimo;
        }

        public EmprestimoModel BuscarEmprestimoPorId(int Id)
        {
            return biblioteca_context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .FirstOrDefault(x => x.Id == Id);
        }

        public EmprestimoModel AtualizarEmprestimo(EmprestimoModel emprestimo)
        {
            EmprestimoModel emprestimoDB = BuscarEmprestimoPorId(emprestimo.Id);

            if (emprestimoDB == null) throw new Exception("Empréstimo não encontrado");

            emprestimoDB.LivroId = emprestimo.LivroId;
            emprestimoDB.UsuarioId = emprestimo.UsuarioId;
            emprestimoDB.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoDB.DataDevolucao = emprestimo.DataDevolucao;

            biblioteca_context.Emprestimos.Update(emprestimoDB);
            biblioteca_context.SaveChanges();

            return emprestimoDB;
        }

        public bool DeletarEmprestimo(int Id)
        {
            EmprestimoModel emprestimoDB = BuscarEmprestimoPorId(Id);

            if (emprestimoDB == null) throw new Exception("Empréstimo não encontrado");

            biblioteca_context.Emprestimos.Remove(emprestimoDB);
            biblioteca_context.SaveChanges();

            return true;
        }
    }
}