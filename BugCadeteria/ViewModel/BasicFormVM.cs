using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class BasicFormVM
    {   
        [Required][StringLength(60, ErrorMessage = "Ingrese menos de 60 caracteres.")][Display(Name = "Nombre")]
        public string? Name { get; set; }
        [Required][StringLength(60, ErrorMessage = "Ingrese menos de 60 caracteres.")][Display(Name = "Dirección")]
        public string? Address { get; set; }
        [Phone][Required][StringLength(20, ErrorMessage = "Ingrese menos de 20 caracteres.")][Display(Name = "Tel")]
        public string? Phone { get; set; }
    }
}