using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Cadete : IPersona
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Address {get; set;}
        public string? Phone {get; set;}
        public List<Pedido>? Orders { get; set; }
    }
}