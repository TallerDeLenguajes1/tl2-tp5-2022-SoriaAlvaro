using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Pedido
    {
        public int? Id { get; set; }
        public string? Obs {get; set; }
        public string? Estate { get; set; }
        public Cliente? Client;

        public Pedido(){
            Client = new Cliente();
        }
    }
}