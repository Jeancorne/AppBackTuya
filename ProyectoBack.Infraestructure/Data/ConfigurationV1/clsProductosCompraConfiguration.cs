using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoBack.Core.Entities.v1;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsProductosCompraConfiguration : IEntityTypeConfiguration<clsProductosCompra>
    {
        public void Configure(EntityTypeBuilder<clsProductosCompra> builder)
        {
            builder.ToTable("tblProductosCompra");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");            
            builder.Property(e => e.IdProducto).HasColumnName("idProducto");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.IdCompra).HasColumnName("idCompra");

            builder.HasOne(a => a.IdCompraNavigation)
                .WithMany(a => a.clsProductosCompra).HasForeignKey(a => a.IdCompra);
            builder.HasOne(a => a.IdProductoNavigation)
                .WithMany(a => a.clsProductosCompra).HasForeignKey(a => a.IdProducto);

        }
    }
}
