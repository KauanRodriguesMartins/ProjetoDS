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

    public IActionResult Adicionar()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }
    public IActionResult Excluir()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
