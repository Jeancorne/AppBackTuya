using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProyectoBack.Application.DTOs.v1.POST
{
    public class clsUsuarioDTO
    {
        [Required(ErrorMessage = "Usuario obligatorio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Contraseña obligatorio")]
        public string password { get; set; }
        [Required(ErrorMessage = "idCajero obligatorio")]
        public int idCajero { get; set; }
    }
}
