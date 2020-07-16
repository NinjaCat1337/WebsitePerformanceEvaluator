using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("Sites")
                .HasKey(s => s.Id);

            builder.Property(s => s.SiteUrl)
                .HasColumnName("SiteUrl")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.HasMany(s => s.TestResults)
                .WithOne(tr => tr.Site)
                .HasForeignKey("IdSite");
        }
    }
}