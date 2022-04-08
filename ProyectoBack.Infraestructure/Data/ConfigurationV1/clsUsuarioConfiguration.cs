using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoBack.Core.Entities.v1;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsUsuarioConfiguration : IEntityTypeConfiguration<clsUsuario>
    {
        public void Configure(EntityTypeBuilder<clsUsuario> builder)
        {
            builder.ToTable("tblUsuario");

            builder.Property(e => e.id).HasColumnName("Id");
            builder.Property(e => e.fechaCreacion).HasColumnName("FechaCreacion");
            builder.Property(e => e.fechaModificacion).HasColumnName("FechaModificacion");                        
            builder.Property(e => e.usuario).HasColumnName("usuario");
            builder.Property(e => e.password).HasColumnName("password");
            builder.Property(e => e.idCajero).HasColumnName("idCajero");
        }
    }
}
