using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObserverAPI.Entities;

namespace ObserverAPI.Data.DataConfigurations
{
    public class LinhasConfiguration : IEntityTypeConfiguration<Linha>
    {
        public void Configure(EntityTypeBuilder<Linha> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .HasMany(p => p.Paradas)
                .WithOne();
        }
    }
}