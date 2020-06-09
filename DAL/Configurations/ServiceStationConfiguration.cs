using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class ServiceStationConfiguration : IEntityTypeConfiguration<ServiceStation>
    {
        public void Configure(EntityTypeBuilder<ServiceStation> builder)
        {
            builder.ToTable("ServiceStations");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasMany(a => a.Cars)
                .WithOne(a => a.ServiceStation)
                .HasForeignKey(a => a.ServiceStationId);
        }
    }
}
