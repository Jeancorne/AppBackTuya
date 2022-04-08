using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IServicioRepository : IRepository<clsUsuario, int>
    {
        Task<clsCajera> obtenerVentasCajero(int idCajero);
        Task<clsUsuario> obtenerUsuarios(string usuario);
        Task<clsCajera> obtenerCajero(int idCajero);
        Task<clsUsuario> obtenerCajeroUsuario(int idCajero);



    }
}
