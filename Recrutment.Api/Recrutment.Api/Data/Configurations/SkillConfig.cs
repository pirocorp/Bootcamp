namespace Recrutment.Api.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class SkillConfig : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .IsRequired();
        }
    }
}
