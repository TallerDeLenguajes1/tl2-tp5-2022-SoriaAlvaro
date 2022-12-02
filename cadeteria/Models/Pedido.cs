using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Pedido
    {
        public int Nro { get; set; }
        public string? Obs { get; set; }
        public Cliente? Client {get; set; }
        public Estado Estate { get; set; }
    }

    public enum Estado {
        Pendiente,
        Viajando,
        Entregado,
        Cancelado
    }
}