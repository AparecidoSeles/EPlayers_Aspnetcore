using System;
using EPlayers_Aspnetcore.Models;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form ["IdEquipe"]);
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            //Chamamos o método Create para salvar a nova equipe no CSV
            equipeModel.Create(novaEquipe);
            
            //Atualiza a lista de equipes na View
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }
    }
}