using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViewModel
{
    public class SavePedidoVM
    {
        public int? Id { get; set; }
        public string? Obs {get; set; }
        public SelectList? listClientes { get; set; }
    }
}