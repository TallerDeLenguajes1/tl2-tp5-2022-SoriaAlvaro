using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_To_Do_List.Models;

namespace Project_To_Do_List.Repositories
{
    public interface ITareaRepository
    {
        List<Tarea> GetAll();
        Tarea GetById(int? id);
        void Create(Tarea taks){}
        void Remove(int id){}
        void Update(Tarea taks){}
    }
}