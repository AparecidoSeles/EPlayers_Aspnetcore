using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interface;

namespace E_Players_AspNETCore.Models
{
    public class Partida : EplayersBase , IPartida
    {
        public int IdPartida   { get; set; }
        
        public int IdJogador1  { get; set; }
        
        public int IdJogador2  { get; set; }
        
        public DateTime HorarioInicio  { get; set; }
        
        public DateTime HorarioTermino { get; set; }
        
        private const string PATH = "Database/Partida.csv";

        public Partida()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Partida p)
        {
            return $"{p.IdPartida}; {p.IdJogador1}; {p.IdJogador2}; {p.HorarioInicio}; {p.HorarioTermino}";
        }

        public void Create(Partida p)
        {
            string[] linhas = {Prepare(p)};
            
            File.AppendAllLines(PATH, linhas);

        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            
            RewriteCSV(PATH, linhas);

        }

        public List<Partida> ReadAll()
        {
            List<Partida> partidas = new List<Partida>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //1;VivoKeyd;img.png
                string[] linha = item.Split(";");

                Partida novaPartida = new Partida();
                novaPartida.IdPartida = int.Parse(linha[0]);
                novaPartida.IdJogador1 = int.Parse(linha[1]);
                novaPartida.IdJogador2 = int.Parse(linha[2]);
                novaPartida.HorarioInicio = DateTime.Parse(linha[3]);
                novaPartida.HorarioTermino =DateTime.Parse(linha[4]);

                partidas.Add(novaPartida);
            }

            return partidas;

        }

        public void Update(Partida p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == p.IdPartida.ToString());
            
            linhas.Add( Prepare(p) );

            RewriteCSV(PATH, linhas);

        }

    }
}