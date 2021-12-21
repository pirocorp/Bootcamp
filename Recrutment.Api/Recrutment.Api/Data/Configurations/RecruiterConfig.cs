namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class RecruiterConfig : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Country)
                .IsRequired();

            builder
                .Property(r => r.Email)
                .IsRequired();

            builder
                .HasIndex(r => r.Email)
                .IsUnique();

            builder
                .Property(r => r.LastName)
                .IsRequired();

            builder
                .Property(r => r.Level)
                .HasDefaultValue(1);
        }
    }
}
