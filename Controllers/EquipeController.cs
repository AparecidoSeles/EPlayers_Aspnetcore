using EPlayers_Aspnetcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_Aspnetcore.Controllers
{

    //https://localhost:5000/Equipe
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        //craimos uma instancia de eqeuipeModel
        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {

            //Listamos todas as equipes  e enviamos para a View, através da ViewBag 
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }  
    }
}