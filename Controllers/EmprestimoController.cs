using Microsoft.AspNetCore.Mvc;
using ProjetoDS.Models;
using ProjetoDS.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;



namespace ProjetoDS.Controllers
{
    [Authorize]
    public class EmprestimoController : Controller
    {
        
        private readonly IBibliotecaRepository _repository;

        public EmprestimoController(IBibliotecaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var emprestimos = _repository.ListarEmprestimos();
            return View(emprestimos);
        }

        [Authorize]
        public IActionResult Adicionar()
        {
            ViewBag.Livros = _repository.ListarLivros();
            ViewBag.Usuarios = _repository.ListarUsuarios();
            return View();
        }

        [HttpPost]
        public IActionResult Criar(EmprestimoModel emprestimo)
        {
            _repository.AdicionarEmprestimo(emprestimo);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Editar(int Id)
        {
            ViewBag.Livros = _repository.ListarLivros();
            ViewBag.Usuarios = _repository.ListarUsuarios();

            var emprestimo = _repository.BuscarEmprestimoPorId(Id);
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Atualizar(EmprestimoModel emprestimo)
        {
            _repository.AtualizarEmprestimo(emprestimo);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Excluir(int Id)
        {
            var emprestimo = _repository.BuscarEmprestimoPorId(Id);
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Deletar(int Id)
        {
            _repository.DeletarEmprestimo(Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}