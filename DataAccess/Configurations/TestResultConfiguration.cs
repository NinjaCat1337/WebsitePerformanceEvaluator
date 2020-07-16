using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TestResultConfiguration : IEntityTypeConfiguration<TestResult>
    {
        public void Configure(EntityTypeBuilder<TestResult> builder)
        {
            builder.ToTable("TestResults")
                .HasKey(tr => tr.Id);

            builder.Property(tr => tr.TestDate)
                .HasColumnName("TestDate")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.HasMany(tr => tr.SiteMapUrlResponseTimes)
                .WithOne(smu => smu.TestResult)
                .HasForeignKey("IdTestResult");
        }
    }
}