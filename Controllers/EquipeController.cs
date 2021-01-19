using System;
using System.IO;
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

        //https://localhost:5000/Equipe/Listar
        [Route("Listar")]
        public IActionResult Index()
        {

            //Listamos todas as equipes  e enviamos para a View, através da ViewBag 
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }  

        //https://localhost:5000/Equipe/Cadastrar
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            
            //Upload inicio 
            //verificamos se o usuario selecionou um arquivo
            if (form.Files.Count > 0)
            {   //recebemos o arquivo que o usuario enviou e armazenamos na variável file
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                //verificamos se o diretorio (pasta) ja exite , se nao o criamos
                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                } 

                //                                      Localhost:5001                       Equipes   imagem.jpg
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder,  file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else 
            {
                novaEquipe.Imagem = "padrao.png";
            }


            //upload término

            //Chamamos o método Create para salvar a nova equipe no CSV
            equipeModel.Create(novaEquipe);
            
            //Atualiza a lista de equipes na View
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar"); 
        }

        //https://localhost:5000/Equipe/Deletar]
        [Route("{id}")]
        public IActionResult Excluir(int id)

        {
            equipeModel.Delete(id);
            ViewBag.Equipe = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}