using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SiteMapUrlConfiguration : IEntityTypeConfiguration<SiteMapUrlResponseTime>
    {
        public void Configure(EntityTypeBuilder<SiteMapUrlResponseTime> builder)
        {
            builder.ToTable("SiteMapUrls")
                .HasKey(smu => smu.Id);

            builder.Property(smu => smu.Url)
                .HasColumnName("Url")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(smu => smu.ResponseTimeMilliseconds)
                .HasColumnName("ResponseTimeMilliseconds")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}