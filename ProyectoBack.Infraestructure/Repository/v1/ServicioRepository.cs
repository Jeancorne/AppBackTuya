using AppBack.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using ProyectoBack.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Repository.v1
{
    public class ServicioRepository : BaseRepository<clsUsuario, int>, IServicioRepository
    {
        public ServicioRepository(DBContext context) : base(context)
        {
        }

        public async Task<clsUsuario> obtenerUsuarios(string usuario)
        {
            var data = await _context.clsUsuario.Where(a => a.usuario == usuario.Trim()).FirstOrDefaultAsync();            
            return data;
        }
        public async Task<clsCajera> obtenerVentasCajero(int idCajero)
        {
            var data = await _context.clsCajera
                                        .Include(a => a.clsCompra)
                                        .ThenInclude(a => a.clsProductosCompra)
                                        .ThenInclude(a => a.IdProductoNavigation)
                                        .Where(a => a.id == idCajero).FirstOrDefaultAsync();
            return data;
        }

        public async Task<clsCajera> obtenerCajero(int idCajero)
        {
            var data = await _context.clsCajera.Where(a => a.id == idCajero).FirstOrDefaultAsync();
            return data;
        }
        public async Task<clsUsuario> obtenerCajeroUsuario(int idCajero)
        {
            var data = await _context.clsUsuario.Where(a => a.idCajero == idCajero).FirstOrDefaultAsync();
            return data;
        }
    }
}
