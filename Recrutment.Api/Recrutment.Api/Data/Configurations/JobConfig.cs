namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    using static DataConstants.Job;

    public class JobConfig : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasKey(j => j.Id);

            builder
                .Property(j => j.Description)
                .IsRequired();

            builder
                .Property(j => j.Salary)
                .HasPrecision(SalaryPrecision, SalaryScale);

            builder
                .Property(j => j.Title)
                .IsRequired();
        }
    }
}
