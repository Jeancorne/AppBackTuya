
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using ProyectoBack.Infraestructure.Data;
using ProyectoBack.Infraestructure.Repository.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBack.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        //Context
        private readonly DBContext _context;

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }              
        private readonly IRepository<clsProductosCompra, int> _clsProductosCompra;
        private readonly IRepository<clsProductos, int> _clsProductos;
        private readonly IRepository<clsCompra, int> _clsCompra;
        private readonly IRepository<clsCajera, int> _clsCajera;
        private readonly IRepository<clsTipoDocumento, int> _clsTipoDocumento;
        private readonly IRepository<clsUsuario, int> _clsUsuario;

        //Instancias genérica
        public IRepository<clsUsuario, int> clsUsuario =>
            _clsUsuario ?? new BaseRepository<clsUsuario, int>(_context);
        
        public IRepository<clsTipoDocumento, int> clsTipoDocumento =>
            _clsTipoDocumento ?? new BaseRepository<clsTipoDocumento, int>(_context);
        public IRepository<clsCajera, int> clsCajera =>
            _clsCajera ?? new BaseRepository<clsCajera, int>(_context);

        public IRepository<clsCompra, int> clsCompra =>
            _clsCompra ?? new BaseRepository<clsCompra, int>(_context);

        public IRepository<clsProductosCompra, int> clsProductosCompra =>
            _clsProductosCompra ?? new BaseRepository<clsProductosCompra, int>(_context);

        public IRepository<clsProductos, int> clsProductos =>
            _clsProductos ?? new BaseRepository<clsProductos, int>(_context);

 
        //Repositorios manuales
        private readonly IServicioRepository _IServicioRepository;
        //Instancias manuales
        public IServicioRepository IServicioRepository =>
            _IServicioRepository ?? new ServicioRepository(_context);




    }
}
