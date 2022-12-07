using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Models;
using Repositories;
using ViewModel;

namespace Controllers
{
    public class CadetesController : Controller
    {
        private readonly ILogger<CadetesController> _logger;
        private readonly IMapper _mapper;
        private readonly ICadeteRepository _cadete;
        public CadetesController(ILogger<CadetesController> logger, IMapper mapper, ICadeteRepository cadete)
        {
            _logger = logger;
            _mapper = mapper;
            _cadete = cadete;
        }
        public IActionResult Index()
        {
            List<Cadete> listcadete = _cadete.GetAll();
            var listcadeteVM = _mapper.Map<List<ListCadetesVM>>(listcadete);
            return View(listcadeteVM);
        }
        /* Crear Cadete */
        public IActionResult SaveCadete(){
            return View();
        }
        public IActionResult Save(SaveCadeteVM cadeteVM){
            var cadete = _mapper.Map<Cadete>(cadeteVM);
            _cadete.Save(cadete);
            return RedirectToAction("SaveCadete");
        }
        /* Borrar Cadete */
        public IActionResult Delete(int id){
            _cadete.Delete(id);
            return RedirectToAction("Index");
        }
        /* Editar Cadete */
        public IActionResult UpdateCadete(int? id){
            var cadete = _cadete.GetById(id);
            var cadeteVM = _mapper.Map<UpdateCadeteVM>(cadete);
            return View(cadeteVM);
        }
        public IActionResult Edit(UpdateCadeteVM cadeteVM){
            var cadete = _mapper.Map<Cadete>(cadeteVM);
            _cadete.Update(cadete);
            return RedirectToAction("Index");
        }
    }
}