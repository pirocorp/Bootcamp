namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class InterviewConfig : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder
                .HasKey(i => new { i.RecruiterId, i.JobId, i.CandidateId });

            builder
                .HasOne(i => i.Candidate)
                .WithMany(c => c.Interviews)
                .HasForeignKey(i => i.CandidateId);

            builder
                .HasOne(i => i.Recruiter)
                .WithMany(r => r.Interviews)
                .HasForeignKey(i => i.RecruiterId);

            builder
                .HasOne(i => i.Job)
                .WithMany(j => j.Interviews)
                .HasForeignKey(i => i.JobId);
        }
    }
}
