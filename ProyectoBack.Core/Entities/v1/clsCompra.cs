using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsCompra : BaseEntity<int>
    {        
        public int? IdCajera { get; set; }
        public decimal PrecioTotal { get; set; }

        public virtual clsCajera idCajeraNavigation { get; set; }
        public virtual ICollection<clsProductosCompra> clsProductosCompra { get; set; }

    }
}
