namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CandidateSkillConfig : IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<CandidateSkill> builder)
        {
            builder
                .HasKey(cs => new {cs.SkillId, cs.CandidateId});

            builder
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.Candidates)
                .HasForeignKey(cs => cs.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(cs => cs.Candidate)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
