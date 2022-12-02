using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Repositories;
using ViewModel;
using Models;

namespace cadeteria.Controllers
{
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepoCadete _cadete;
        public CadeteController(ILogger<CadeteController> logger, IMapper mapper, IRepoCadete cadete)
        {
            _logger = logger;
            _mapper = mapper;
            _cadete = cadete;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult SaveCadete(){
            return View();
        }
        [HttpPost]
        public IActionResult GuardarCadete(SaveCadeteVM cadVM){
            var cadete = _mapper.Map<Cadete>(cadVM);
            _cadete.Save(cadete);
            return RedirectToAction("SaveCadete");
        }
        private List<ListCadetesVM> listCadVM;
        public IActionResult ListCadetes(){
            List<Cadete> cadetes = _cadete.GetAll();
            listCadVM = _mapper.Map<List<ListCadetesVM>>(cadetes);
            return View(listCadVM);
        }

        public IActionResult BorrarCadete(int id){
            _cadete.Delete(id);/* 
            listCadVM.Remove(listCadVM.Single(x => x.Id == id)); */
            return RedirectToAction("ListCadetes");
        }
        public IActionResult EditCadete(int? id){
            var cadete = _cadete.GetById(id);
            UpdateCadeteVM updateCad = _mapper.Map<UpdateCadeteVM>(cadete);
            return View(updateCad);
        }
        [HttpPost]
        public IActionResult EditCadete(UpdateCadeteVM updateCad){
            var cadete = _mapper.Map<Cadete>(updateCad);
            _cadete.Update(cadete);
            return RedirectToAction("ListCadetes");
        }
    }
}