using Microsoft.AspNetCore.Mvc;
using ProjetoDS.Models;
using ProjetoDS.Repository;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoDS.Controllers
{
   [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        private readonly IBibliotecaRepository _repository;

        public UsuarioController(IBibliotecaRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var usuarios = _repository.ListarUsuarios();
            return View(usuarios);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Criar(UsuarioModel usuario)
        {
            _repository.AdicionarUsuario(usuario);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Editar(int Id)
        {
            var usuario = _repository.BuscarUsuarioPorId(Id);
            return View(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Atualizar(UsuarioModel usuario)
        {
            _repository.AtualizarUsuario(usuario);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Excluir(int Id)
        {
            var usuario = _repository.BuscarUsuarioPorId(Id);
            return View(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
