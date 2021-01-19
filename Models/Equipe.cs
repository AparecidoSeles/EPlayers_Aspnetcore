using System;
using System.Collections.Generic;
using System.IO;
using EPlayers_Aspnetcore.Interfaces;

namespace EPlayers_Aspnetcore.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string  Imagem { get; set; }

        private const string PATH = "DataBase/Equipe.csv";


        //método construtor não necessita de retorno 
        // so chamá-lo pelo nome ele ja age automaticamente
        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }
        public void Create(Equipe e)
        {
            //preparamos um areey de string para o método AppendAllLines
            string[] linhas = { Prepare(e) };
            // acrescetamos a nova linha 
            File.AppendAllLines(PATH, linhas);
        }

        // Criamos p método para preparar a linha do csv
        public string Prepare(Equipe e)
        {
            //interpolação no csv ultiliza (;) e não (+)
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        //método para deletar 
        public void Delete(int id)
        {
             List<string> linhas = ReadAllLinesCVS(PATH);

             //2;SNK;snk.jpg
             //Rempvemos a linhas com o codigo comparado
             //ToString Converte para texto
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            //reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //Ler as linhas do csv
            string [] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {   // 1;Vivokeyd;vivo.jpg
                string[] linha = item.Split(";");           // Split(";") serve para quebrar a linha 

                Equipe novaEquipe   = new Equipe();
                novaEquipe.IdEquipe = Int32.Parse( linha [0] );
                novaEquipe.Nome     = linha [1];
                novaEquipe.Imagem   = linha [2];

                equipes.Add(novaEquipe);
                
            }

            return equipes; 
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCVS(PATH);

             //2;SNK;snk.jpg
             //Rempvemos a linhas com o codigo comparado
             //ToString converte para texto o IdEquipe  
            linhas.RemoveAll(
            x => 
            x.Split(";")[0]
            == e.IdEquipe.ToString());

            //adicionamos na lista a equipe alterada
            linhas.Add(Prepare (e));

            //reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }
    }
} 