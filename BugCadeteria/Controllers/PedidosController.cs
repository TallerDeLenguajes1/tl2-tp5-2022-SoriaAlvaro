using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using ViewModel;
using Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugCadeteria.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _cliente;
        private readonly IPedidoRepository _pedido;
        public PedidosController(ILogger<PedidosController> logger, IMapper mapper, IClienteRepository cliente, IPedidoRepository pedido)
        {
            _logger = logger;
            _mapper = mapper;
            _cliente = cliente;
            _pedido = pedido;
        }

        public IActionResult Index()
        {   var pedidos = _pedido.GetAll();
            var pedidosVM = _mapper.Map<List<IndexVM>>(pedidos);
            return View(pedidosVM);
        }
        public IActionResult SavePedido(){
            var clientesList = _cliente.GetAll();
            var pedidoVM = new SavePedidoVM();
            pedidoVM.listClientes = new SelectList(clientesList, "Id", "Name");
            if(clientesList.Any())
                pedidoVM.Id = clientesList.First().Id;
            return View(pedidoVM);
        }

        public IActionResult Save(SavePedidoVM pedidoVM){
            var idCliente = pedidoVM.Id;
            var pedido = _mapper.Map<Pedido>(pedidoVM);
            _pedido.Save(pedido, idCliente);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


    }
}