using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public interface IPersona
    {
        int? Id { get; set; }
        string? Name { get; set; }
        string? Address { get; set; }
        string? Phone { get; set; }
    }
}