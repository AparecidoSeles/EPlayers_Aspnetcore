using System.Collections.Generic;
using System;
using System.IO;
using EPlayers_Aspnetcore.Interfaces;
using EPlayers_Aspnetcore.Models;

namespace EPlayers_Aspnetcore.Models
{
    public class Jogador : EplayersBase , IJogador
    {
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        //Login
        public string Email{get; set;}
        public string Senha { get; set; }

        //Método construtor
        public const string PATH = "DataBase/Jogador.csv";
        
        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Prepara a linha para a estrutura do  objeto jogador
        /// </summary>
        /// <param name="j"></param>
        /// <returns>retorna a linha em formato .csv</returns>
        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador}; {j.Nome}; {j.Email}; {j.Senha}";
        }

        /// <summary>
        /// Adiciona um jogador ao CSV
        /// </summary>
        /// <param name="j"></param>
        public void Create(Jogador j)
        {
            //preparamos um arrey de string para o método AppendAllLines
            string[] linhas = {PrepararLinha(j)};
            // acrescetamos um novo jogador
            File.AppendAllLines(PATH, linhas );
        }

        /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <returns>Lista de jogadors</returns>
        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha[0]);
                jogador.Nome = linha[1];
                jogador.Email = linha[2];
                jogador.Senha = linha[3];

                jogadores.Add(jogador);
            }
            return jogadores;
        }

        /// <summary>
        /// Alterar um jogador
        /// </summary>
        /// <param name="j"></param>
        public void Upadate(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( PrepararLinha(j) );                        
            RewriteCSV(PATH, linhas); 
        }

        /// <summary>
        /// Excluir um jogador
        /// </summary>
        /// <param name="IdJogador"></param>
        public void Delete(int IdJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            //1;Equipe Fla;FLA 1.png
            linhas.RemoveAll(x => x.Split(";")[0] == IdJogador.ToString());
            RewriteCSV(PATH, linhas);
        }

        
    }
}