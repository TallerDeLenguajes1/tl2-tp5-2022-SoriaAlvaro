using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Project_To_Do_List.Models;
using Project_To_Do_List.ViewModels;
using Project_To_Do_List.Repositories;

namespace Project_To_Do_List.Controllers
{
    public class TareasController : Controller
    {
        private readonly ILogger<TareasController> _logger;
        private readonly ITareaRepository _task;
        private readonly IMapper _mapper;
        public TareasController(
            ILogger<TareasController> logger,
            ITareaRepository task,
            IMapper mapper)
        {
            _logger = logger;
            _task = task;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tasks(){
            List<Tarea> listTasks = _task.GetAll();
            var listTasksVM = _mapper.Map<List<ViewAllTasksVM>>(listTasks);
            return View(listTasksVM);
        }

        public IActionResult Save(CreateTaskVM taskVM){
            var task = _mapper.Map<Tarea>(taskVM);
            _task.Create(task);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTask(int id){
            _task.Remove(id);
            return RedirectToAction("Tasks");
        }
        public IActionResult EditTask(int? id){
            var task = _task.GetById(id);
            System.Console.WriteLine("este es el id: "+id);
            var taskVM = _mapper.Map<EditTaskVM>(task);
            return View(taskVM);
        }
        public IActionResult Edit(EditTaskVM taskVM){
            var task = _mapper.Map<Tarea>(taskVM);
            _task.Update(task);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}