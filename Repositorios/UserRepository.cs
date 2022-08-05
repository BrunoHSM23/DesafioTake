using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integracao.Models.Entidades;

namespace Integracao.Repositorios
{
    public class UserRepository
    {
        public static UsuarioAD Get(string username, string password)
        {
            var users = new List<UsuarioAD>();
            users.Add(new UsuarioAD { Id = 1, Username = "Bruno", Password = "TakeBlip", Role = "Admin" });
            users.Add(new UsuarioAD { Id = 2, Username = "Henrique", Password = "Blip", Role = "Admin" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
