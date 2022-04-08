using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Core.Entities.v1;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IServicio
    {
        Task<clsCompra> registrarCompra(List<clsCompraDTO> lsCompra, int idUsuario);        
        Task<clsUsuario> obtenerUsuario(string usuario, string password);        
        Task<clsUsuario> crearUsuario(clsUsuarioDTO login);
        Task<clsCajera> obtenerVentasCajero(int idCajera);

    }
}
