using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using ViewModel;
using AutoMapper;
using Repositories;

namespace BugCadeteria.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        
        private readonly IMapper _mapper;
        private readonly IClienteRepository _cliente;
        public ClientesController(ILogger<ClientesController> logger, IMapper mapper, IClienteRepository cliente)
        {
            _logger = logger;
            _mapper = mapper;
            _cliente = cliente;
        }

        public IActionResult Index()
        {
            List<Cliente> listCliente = _cliente.GetAll();
            var listClienteVM = _mapper.Map<List<ListClientesVM>>(listCliente);
            return View(listClienteVM);
        }

        /* Crear cliente */
        public IActionResult SaveCliente(){
            return View();
        }
        public IActionResult Save(SaveClienteVM clienteVM){
            var cliente = _mapper.Map<Cliente>(clienteVM);
            _cliente.Save(cliente);
            return RedirectToAction("Savecliente");
        }
        /* Borrar cliente */
        public IActionResult Delete(int id){
            _cliente.Delete(id);
            return RedirectToAction("Index");
        }
        /* Editar cliente */
        public IActionResult UpdateCliente(int? id){
            var cliente = _cliente.GetById(id);
            var clienteVM = _mapper.Map<UpdateClienteVM>(cliente);
            return View(clienteVM);
        }
        public IActionResult Edit(UpdateClienteVM clienteVM){
            var cliente = _mapper.Map<Cliente>(clienteVM);
            _cliente.Update(cliente);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}