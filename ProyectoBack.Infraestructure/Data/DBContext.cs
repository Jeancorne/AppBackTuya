using Microsoft.EntityFrameworkCore;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Data
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }
        /// <summary>
        /// ///
        /// </summary>
        public virtual DbSet<clsUsuario> clsUsuario { get; set; }
        public virtual DbSet<clsTipoDocumento> clsTipoDocumento { get; set; }
        public virtual DbSet<clsCajera> clsCajera { get; set; }
        public virtual DbSet<clsCompra> clsCompra { get; set; }
        public virtual DbSet<clsProductosCompra> clsProductosCompra { get; set; }
        public virtual DbSet<clsProductos> clsProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
