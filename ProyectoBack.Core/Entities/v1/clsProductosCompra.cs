using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsProductosCompra : BaseEntity<int>
    {        
        public int? IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int? IdCompra { get; set; }
        public virtual clsCompra IdCompraNavigation { get; set; }
        public virtual clsProductos IdProductoNavigation { get; set; }

    }
}
