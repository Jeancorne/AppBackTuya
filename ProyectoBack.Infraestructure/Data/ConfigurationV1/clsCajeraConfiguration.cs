using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoBack.Core.Entities.v1;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsCajeraConfiguration : IEntityTypeConfiguration<clsCajera>
    {
        public void Configure(EntityTypeBuilder<clsCajera> builder)
        {
            builder.ToTable("tblCajera");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            builder.Property(e => e.Identificacion).HasColumnName("identificacion");

            builder.HasOne(a => a.IdTipoDocumentoNavigation)
                .WithMany(a => a.clsCajera).HasForeignKey(a => a.IdTipoDocumento);


        }
    }
}
