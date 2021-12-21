namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class JobSkillConfig : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
            builder
                .HasKey(js => new { js.SkillId, js.JobId });

            builder
                .HasOne(js => js.Skill)
                .WithMany(s => s.Jobs)
                .HasForeignKey(js => js.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(js => js.Job)
                .WithMany(j => j.Skills)
                .HasForeignKey(js => js.JobId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
