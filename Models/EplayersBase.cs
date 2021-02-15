using System.Collections.Generic;
using System.IO;

namespace E_Players_AspNETCore.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFile(string _path)
        {
            string folder = _path.Split("/")[0];
            string file = _path.Split("/")[1];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }

        public List<string> ReadAllLinesCSV(string PATH)
        {
            List<string> linhas = new List<string>();

            // Using -> Responsável pro abrir e fechar o arquivo automaticamente
            // StreamReader -> Ler dados de um arquivo
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;

                // Percorres as linhas com um laço while
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void RewriteCSV(string PATH, List<string> linhas)
        {
            // StreamWritter -> escrever dados em um arquivo
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}