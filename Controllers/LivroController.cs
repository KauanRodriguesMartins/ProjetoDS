using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoDS.Data;
using ProjetoDS.Models;
using ProjetoDS.Repository;

namespace ProjetoDS.Controllers;

public class LivroController : Controller
{
    
    private readonly IBibliotecaRepository biblioteca_repository;

    public LivroController(IBibliotecaRepository bibliotecaRepository)
    {
        biblioteca_repository = bibliotecaRepository;
    }

    public IActionResult Index()
    {
        List<LivroModel> livro = biblioteca_repository.ListarLivros();  
        return View(livro);
    }


    [HttpPost]
    public IActionResult Criar(LivroModel livro)
    {
        biblioteca_repository.Adicionar(livro);
        return RedirectToAction("Index");
    }
    public IActionResult Adicionar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Atualizar(LivroModel livro)
    {
        biblioteca_repository.Atualizar(livro);
        return RedirectToAction("Index");
    }
    public IActionResult Editar(int Id)
    {
        var livro = biblioteca_repository.BuscarId(Id);
        return View(livro);
    }

    [HttpPost]
    public IActionResult Deletar (int Id)
    {
        biblioteca_repository.Deletar(Id);
        return RedirectToAction("Index");
    }
    public IActionResult Excluir(int Id)
    {
        var livro = biblioteca_repository.BuscarId(Id);
        return View(livro);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
