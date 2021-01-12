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

        // Criamos p método para preparar a linha do csv
        public string Prepare(Equipe e)
        {
            //interpolação no csv ultiliza (;) e não (+)
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Create(Equipe e)
        {
            //preparamos um areey de string para o método AppendAllLines
            string[] linhas =  { Prepare(e) };
            // acrescetamos a nova linha 
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //Ler as linhas do csv
            string [] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {   // 1;Vivokeyd;vivo.jpg
                string[] linha = item.Split(";");           // Split serve para quebrar a linha 

                Equipe novaEquipe   = new Equipe();
                novaEquipe.IdEquipe = int.Parse(linha [0] );
                novaEquipe.Nome     = linha [1];
                novaEquipe.Imagem   = linha [2];

                equipes.Add(novaEquipe);
                
            }

            return equipes; 
        }

        public void Update(Equipe e)
        {
            
        }
    }
} 