using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_To_Do_List.Models;
using Project_To_Do_List.ViewModels;
using AutoMapper;

namespace Project_To_Do_List
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<CreateTaskVM, Tarea>().ReverseMap();
            CreateMap<EditTaskVM, Tarea>().ReverseMap();
            CreateMap<ViewAllTasksVM, Tarea>().ReverseMap();
        }
    }
}