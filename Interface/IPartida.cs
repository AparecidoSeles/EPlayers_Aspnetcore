using System.Collections.Generic;
using E_Players_AspNETCore.Models;

namespace E_Players_AspNETCore.Interface
{
    public interface IPartida
    {
        void Create(Partida p);

        List<Partida> ReadAll();

        void Update(Partida p);

        void Delete(int id);

    }
}