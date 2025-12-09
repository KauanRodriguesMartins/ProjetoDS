using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoDS.Models;

namespace ProjetoDS.Controllers;

public class EmprestimoController : Controller
{
    private readonly ILogger<EmprestimoController> _logger;

    public EmprestimoController(ILogger<EmprestimoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
