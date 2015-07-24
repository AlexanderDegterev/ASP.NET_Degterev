using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StatisticsOfSales.DAL.Models.Mapping
{
    public class ManagerMap : EntityTypeConfiguration<Manager>
    {
        public ManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.ManagerID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Managers");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.ManagerName).HasColumnName("ManagerName");
            this.Property(t => t.ManagerSurname).HasColumnName("ManagerSurname");
        }
    }
}
