using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoBack.Core.Entities.v1;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsTipoDocumentoConfiguration : IEntityTypeConfiguration<clsTipoDocumento>
    {
        public void Configure(EntityTypeBuilder<clsTipoDocumento> builder)
        {
            builder.ToTable("tblTipoDocumento");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
        }
    }
}
