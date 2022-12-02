using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class FormValidationVM
    {
        [Required][StringLength(60, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 60 carateres.")][Display(Name = "Nombre")]
        public string? Name {get; set; }
        [Required][StringLength(60, MinimumLength = 3, ErrorMessage = "El campo debe tener entre 3 y 60 carateres.")][Display(Name = "Dirección")]
        public string? Address {get; set; }
        [Required][StringLength(20, MinimumLength = 10, ErrorMessage = "El campo debe tener entre 10 y 20 carateres.")][Phone][Display(Name = "Tel")]
        public string? Phone {get; set; }
    }
}