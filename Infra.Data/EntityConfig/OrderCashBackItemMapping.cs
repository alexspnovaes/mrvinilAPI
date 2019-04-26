using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfig
{
    public class OrderCashBackItemMapping : EntityTypeConfiguration<OrderCashBackItem>
    {
        public void OrderCashBackItemConfiguration()
        {
            ToTable("OrderCashBackItem");
            HasKey(p => p.Id);
            Property(p => p.ValueCachBack)
                .HasColumnType("money")
                .IsRequired();
            Property(p => p.PerCachBack)
                .HasColumnType("decimal (5,2)")
                .IsRequired();
            HasRequired(p => p.OrderItem);
        }
    }
}
