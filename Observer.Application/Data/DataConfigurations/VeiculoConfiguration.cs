using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObserverAPI.Entities;

namespace ObserverAPI.Data.DataConfigurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .HasOne<Linha>()
                .WithOne()
                .HasForeignKey<Veiculo>(v => v.LinhaId);
        }
    }
}