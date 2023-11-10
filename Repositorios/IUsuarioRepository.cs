using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using tl2_tp09_2023_TomasDLV.Models;

namespace tl2_tp09_2023_TomasDLV.Repositorios
{
    public class IUsuarioRepository
    {
        public interface IDirectoresRepository
        {
            public void Create(Usuario usuario);
            
            public void Update(int id,Usuario usuario);
            public List<Usuario> GetAll();
            public Usuario GetById(int idUsuario);
            public void Remove(int id);
        }
    }
}