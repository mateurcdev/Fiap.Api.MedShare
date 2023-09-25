using Fiap.Api.MedShare.Models;
using Microsoft.AspNetCore.Mvc;
namespace Fiap.Api.MedShare.Controllers;

public class RepresentanteController : Controller
{

    private IList<RepresentanteModel> representantes;

    public RepresentanteController()
    {
        // De uma forma rudimentar, podemos dizer que esse bloco de código 
        // simula o retorno de uma consulta no banco de dados
        representantes = new List<RepresentanteModel>();
        representantes.Add(new RepresentanteModel(1, "444.143.658-05", "José Carlos Silva"));
        representantes.Add(new RepresentanteModel(2, "062.572.723-19", "Maria José Fernandes"));
        representantes.Add(new RepresentanteModel(3, "920.680.661-06", "Carlos Silva"));
        representantes.Add(new RepresentanteModel(4, "111.222.333-06", "Joao Triste"));
        representantes.Add(new RepresentanteModel(4, "111.222.333-06", "Rafael Feliz"));
    }

    public IActionResult Index()
    {
        return View(representantes); // <-- Atenção
    }
    
    [HttpGet]
    public IActionResult Cadastrar()
    {
       
        Console.WriteLine("Executou a Action Cadastrar()");

       
        return View(new RepresentanteModel());
    }


    [HttpPost]
    public IActionResult Cadastrar(RepresentanteModel representante)
    {

        // Se o ModelState não possuir nenhum erro
        if (ModelState.IsValid)
        {
            // Imprime os valores do modelo
            Console.WriteLine("Descrição: " + representante.Cpf);
            Console.WriteLine("Comercializado: " + representante.NomeRepresentante);

            // Simila que os dados foram gravados.
            Console.WriteLine("Gravando o Representante");

            TempData["mensagem"] = "Representante cadastrado com sucesso";

            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction("Index", "Representante");

            // Caso o ModelState tenha algum erro
        }
        else
        {
            // retorna para tela do formulário
            return View(representante);
        }
    }
}