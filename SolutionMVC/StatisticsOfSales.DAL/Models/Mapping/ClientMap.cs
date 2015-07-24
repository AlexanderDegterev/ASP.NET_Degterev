using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StatisticsOfSales.DAL.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Clients");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.ClientName).HasColumnName("ClientName");
        }
    }
}
