using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsCajera : BaseEntity<int>
    {
        public string? Nombre { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string? Identificacion { get; set; }
        public virtual clsTipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<clsCompra> clsCompra { get; set; }
        


    }
}
