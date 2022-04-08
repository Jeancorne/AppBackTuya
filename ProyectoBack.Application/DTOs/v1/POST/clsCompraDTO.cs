using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.DTOs.v1.POST
{
    public class clsCompraDTO
    {    
        [Required(ErrorMessage = "idProducto obligatorio"), RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public int idProducto { get; set; }
        [Required(ErrorMessage = "cantidad obligatorio"), RegularExpression("^[0-9]*$", ErrorMessage = "Solo se permiten números")]
        public int cantidad { get; set; }
    }
}
