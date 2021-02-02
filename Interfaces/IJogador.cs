using System.Collections.Generic;
using EPlayers_Aspnetcore.Models;

namespace EPlayers_Aspnetcore.Interfaces
{
    public interface IJogador
    {
         //Criar = Creat
         void Create (Jogador j);
         //Ler = Read
         List<Jogador> ReadAll();
         //Alterar = Upadate
         void Upadate(Jogador j);
         //Excluir = Delete
         void Delete(int Id);
    }
}
