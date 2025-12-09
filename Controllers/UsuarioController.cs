using Microsoft.AspNetCore.Mvc;
using ProjetoDS.Models;
using ProjetoDS.Repository;
using System.Diagnostics;

namespace ProjetoDS.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IBibliotecaRepository _repository;

        public UsuarioController(IBibliotecaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var usuarios = _repository.ListarUsuarios();
            return View(usuarios);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            _repository.AdicionarUsuario(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int Id)
        {
            var usuario = _repository.BuscarUsuarioPorId(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioModel usuario)
        {
            _repository.AtualizarUsuario(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int Id)
        {
            var usuario = _repository.BuscarUsuarioPorId(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Deletar(int Id)
        {
            _repository.DeletarUsuario(Id);
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
