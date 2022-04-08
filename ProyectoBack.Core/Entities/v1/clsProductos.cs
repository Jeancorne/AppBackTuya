using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsProductos : BaseEntity<int>
    {
        [Required(ErrorMessage = "Nombre del producto obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Precio obligatorio"), RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "Solo se permiten números")]
        public decimal Precio { get; set; }
        public virtual ICollection<clsProductosCompra> clsProductosCompra { get; set; }
    }
    
}
