
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IUnitOfWork : IDisposable
    {
        void saveChanges();
        Task SaveChangesAsync();
                
        IRepository<clsProductos, int> clsProductos { get; }
        IRepository<clsProductosCompra, int> clsProductosCompra { get; }
        IRepository<clsCompra, int> clsCompra { get; }
        IRepository<clsCajera, int> clsCajera { get; }
        IRepository<clsTipoDocumento, int> clsTipoDocumento { get; }
        IRepository<clsUsuario, int> clsUsuario { get; }
        //Repositorios manuales
        IServicioRepository IServicioRepository { get; }


    }
}
