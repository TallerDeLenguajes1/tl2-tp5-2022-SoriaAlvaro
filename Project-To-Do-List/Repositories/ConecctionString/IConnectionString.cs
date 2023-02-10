using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_To_Do_List.Repositories
{
    public interface IConnectionString
    {
       string? GetString(); 
    }
}