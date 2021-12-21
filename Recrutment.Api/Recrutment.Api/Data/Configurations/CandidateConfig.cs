namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CandidateConfig : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Bio)
                .IsRequired();

            builder
                .Property(c => c.FirstName)
                .IsRequired();
            
            builder
                .Property(c => c.LastName)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .IsRequired();

            builder
                .HasIndex(c => c.Email)
                .IsUnique();

            builder
                .Property(c => c.RecruiterId)
                .IsRequired();

            builder
                .HasOne(c => c.Recruiter)
                .WithMany(r => r.Candidates)
                .HasForeignKey(c => c.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
