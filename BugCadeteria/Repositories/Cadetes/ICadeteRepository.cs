using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Models;

namespace Repositories
{
    public interface ICadeteRepository
    {
        void Save(Cadete cadete){}
        void Update(Cadete cadete){}
        void Delete(int? id){}
        Cadete? GetById(int? id);
        List<Cadete> GetAll();
    }
}