using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObserverAPI.Entities;

namespace ObserverAPI.Data.DataConfigurations
{
    public class ParadasConfiguration : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}