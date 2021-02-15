using System.Collections.Generic;
using E_Players_AspNETCore.Models;

namespace E_Players_AspNETCore.Interface
{
    public interface IJogador
    {
        void Create(Jogador j);

        List<Jogador> ReadAll();

        void Update(Jogador j);

        void Delete(int id);

    }
}