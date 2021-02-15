using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interface;

namespace E_Players_AspNETCore.Models
{
    public class Jogador : EplayersBase , IJogador
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }


        public string Email { get; set; }

        public string Senha { get; set; }
        
        public int IdEquipe { get; set; }
        
        public string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }
        public void Create(Jogador j)
        {
            string[] linhas = {Prepare(j)};
            
            File.AppendAllLines(PATH, linhas);
        }

        public string Prepare(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.Email};{j.Senha}";
        }


        public void Delete(int idJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == idJogador.ToString());
            
            RewriteCSV(PATH, linhas);

        }
        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //1;VivoKeyd;img.png
                string[] linha = item.Split(";");

                Jogador novoJogador = new Jogador();
                
                novoJogador.IdJogador = int.Parse(linha [0]);
                novoJogador.Nome = linha [1];
                novoJogador.Email = linha [2];
                novoJogador.Senha = linha [3];

                jogadores.Add(novoJogador);
            }

            return jogadores;

        }

        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            
            linhas.Add( Prepare(j) );

            RewriteCSV(PATH, linhas);

        }

    }
}