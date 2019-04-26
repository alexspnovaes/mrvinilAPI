using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class OrderItemMapping : EntityTypeConfiguration<OrderItem>
    {
        public void OrderItemConfiguration()
        {
            ToTable("OrderItem");
            HasKey(p => p.Id);
            Property(p => p.UnitPrice).HasColumnType("money").IsRequired();
            Property(p => p.Quantity).IsRequired();
            HasRequired(p => p.Disk);
        }
    }
}
