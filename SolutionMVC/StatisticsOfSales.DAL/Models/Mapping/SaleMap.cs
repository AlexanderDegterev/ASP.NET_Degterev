using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StatisticsOfSales.DAL.Models.Mapping
{
    public class SaleMap : EntityTypeConfiguration<Sale>
    {
        public SaleMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Sales");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.SUM).HasColumnName("SUM");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.ClientID);
            this.HasRequired(t => t.Manager)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.ManagerID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Sales)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
