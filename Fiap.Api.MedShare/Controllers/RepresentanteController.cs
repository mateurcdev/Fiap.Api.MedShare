using Fiap.Api.MedShare.Controllers.Filters;
using Fiap.Api.MedShare.Models;
using Fiap.Api.MedShare.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Fiap.Api.MedShare.Controllers;

public class RepresentanteController : Controller
{

    private RepresentanteRepository representanteRepository;

    public RepresentanteController()
    {

        representanteRepository = new RepresentanteRepository();
    }

    [LogFilter]
    public IActionResult Index()
    {
        // Retornando para View a lista de Representantes
        var lista = representanteRepository.Listar();

        return View(lista);
    }

    // Anotação de uso do Verb HTTP Get
    [HttpGet]
    public IActionResult Cadastrar()
    {
        // Retorna para a View Cadastrar um 
        // objeto modelo com as propriedades em branco 
        return View(new RepresentanteModel());
    }

    // Anotação de uso do Verb HTTP Post
    [HttpPost]
    public IActionResult Cadastrar(RepresentanteModel representante)
    {
        if (ModelState.IsValid)
        {

            representanteRepository.Inserir(representante);

            TempData["mensagem"] = "Representante cadastrado com sucesso";
            return RedirectToAction("Index", "Representante");
        }
        else
        {
            return View(representante);
        }
    }


    [HttpGet]
    public IActionResult Editar([FromRoute] int id)
    {
        var representante = representanteRepository.Consultar(id);
        return View(representante);
    }

    [HttpPost]
    public IActionResult Editar(RepresentanteModel representante)
    {
        if (ModelState.IsValid)
        {
            representanteRepository.Alterar(representante);

            TempData["mensagem"] = "Representante alterado com sucesso";
            return RedirectToAction("Index", "Representante");
        }
        else
        {
            return View(representante);
        }

    }


    [HttpGet]
    public IActionResult Consultar(int id)
    {
        var representante = representanteRepository.Consultar(id);
        return View(representante);
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        representanteRepository.Excluir(id);

        TempData["mensagem"] = "Representante excluído com sucesso";
        return RedirectToAction("Index", "Representante");
    }


}