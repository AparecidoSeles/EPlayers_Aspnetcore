using System.Collections.Generic;
using E_Players_AspNETCore.Models;

namespace E_Players_AspNETCore.Interface
{
    public interface INoticia
    {
        void Create(Noticia n);

        List<Noticia> ReadAll();

        void Update(Noticia n);

        void Delete(int id);
    }
}