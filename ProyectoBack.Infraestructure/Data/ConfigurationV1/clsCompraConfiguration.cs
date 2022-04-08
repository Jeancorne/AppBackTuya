using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoBack.Core.Entities.v1;


namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsCompraConfiguration : IEntityTypeConfiguration<clsCompra>
    {
        public void Configure(EntityTypeBuilder<clsCompra> builder)
        {
            builder.ToTable("tblCompra");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");            
            builder.Property(e => e.IdCajera).HasColumnName("idCajera");
            builder.Property(e => e.PrecioTotal).HasColumnName("precioTotal");

            builder.HasOne(a => a.idCajeraNavigation)
                .WithMany(a => a.clsCompra).HasForeignKey(a => a.IdCajera);

        }
    }
}
