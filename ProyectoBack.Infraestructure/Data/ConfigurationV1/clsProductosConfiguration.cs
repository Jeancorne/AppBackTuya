using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoBack.Core.Entities.v1;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsProductosConfiguration : IEntityTypeConfiguration<clsProductos>
    {
        public void Configure(EntityTypeBuilder<clsProductos> builder)
        {
            builder.ToTable("tblProductos");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.Precio).HasColumnName("precio");            
        }
    }
}
