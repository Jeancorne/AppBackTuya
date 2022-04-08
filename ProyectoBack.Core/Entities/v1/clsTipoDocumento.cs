using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProyectoBack.Core.Entities.v1
{
    public class clsTipoDocumento : BaseEntity<int>
    {
        [Required(ErrorMessage = "Nombre del tipo documento obligatorio")]
        public string Nombre { get; set; }
        [JsonIgnore]
        public virtual ICollection<clsCajera> clsCajera { get; set; }
    }
}
