using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PSC06.Models.ViewModels
{
    public class QueryViewModels
    {
        public int _Id { get; set; }
        public string _Email { get; set; }
        public int? _Edad {  get; set; }
    }

    public class AddUserViewModels
    {
        [Required]
        [Display(Name ="Nombre Usuario")]
        public string _Nombre { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="Digite un correo",  MinimumLength = 6)]
        public string _Correo { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string _Clave { get; set; }

        [Required]
        [Display(Name = "Confirma Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Revisa el password")]
        public string _ClaveConfirma { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int _Edad { get; set; }
    }

    public class EditUserViewModels
    {
        public int _Id { get; set; }
        [Required]
        [Display(Name = "Nombre Usuario")]
        public string _Nombre { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Digite un correo", MinimumLength = 6)]
        public string _Correo { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string _Clave { get; set; }

        [Required]
        [Display(Name = "Confirma Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Revisa el password")]
        public string _ClaveConfirma { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int? _Edad { get; set; }
    }
}