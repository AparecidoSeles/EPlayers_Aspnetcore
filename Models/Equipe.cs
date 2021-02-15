using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interface;

namespace E_Players_AspNETCore.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }
        
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        // Método para preparar a linha no CSV
        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Create(Equipe e)
        {   
            // Preparado o Array de String para o método AppendAllLines
            string[] linhas = {Prepare(e)};
            
            // Acrescentando novas linhas
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // Removemos as linhas com código comparado
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            
            // Reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);

        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //1;VivoKeyd;img.png
                string[] linha = item.Split(";");

                Equipe novaEquipe = new Equipe();
                novaEquipe.IdEquipe = int.Parse(linha[0]);
                novaEquipe.Nome = linha[1];
                novaEquipe.Imagem = linha[2];

                equipes.Add(novaEquipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // Removemos as linhas com código comparado
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            
            //Adicionamos na lista a equipe alterada
            linhas.Add( Prepare(e) );

            // Reescreve o csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }
    }
}