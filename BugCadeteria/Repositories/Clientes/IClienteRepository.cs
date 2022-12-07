using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Models;

namespace Repositories
{
    public interface IClienteRepository
    {
        void Save(Cliente cliente){}
        void Update(Cliente cliente){}
        void Delete(int? id){}
        Cliente? GetById(int? id);
        List<Cliente> GetAll();
    }
}