using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_To_Do_List.ViewModels
{
    public class CreateTaskVM
    {
        [Required][StringLength(60,MinimumLength = 5, ErrorMessage = "Ingrese menos de 60 caracteres.")]
        public string? title { get; set; }
        [Required][StringLength(540,MinimumLength = 5, ErrorMessage = "Ingrese menos de 240 caracteres.")]
        public string? description { get; set; }
    }
}