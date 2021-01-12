using System.Collections.Generic;
using EPlayers_Aspnetcore.Models;

namespace EPlayers_Aspnetcore.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);
        List<Equipe> ReadAll();
        void Update(Equipe e);  
        void Delete(int id);
    }
}