using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class ClientMapping : EntityTypeConfiguration<Client>
    {
        public void ClientConfiguration()
        {
            HasKey(p => p.Id);

            Property(o => o.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            Property(o => o.UserName)
                .HasColumnName("Username")
                .HasMaxLength(30)
                .IsRequired();

            Property(o => o.Email)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .IsRequired();

            Property(o => o.ClientUniqueId)
              .HasColumnName("ClientUniqueId")
              .HasMaxLength(20)
              .IsRequired();

            Property(o => o.Password)
              .HasColumnName("Password")
              .HasMaxLength(100)
              .IsRequired();
        }
    }
}
