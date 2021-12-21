namespace Recrutment.Api.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class RecrutmentDbContext : DbContext
    {
        public RecrutmentDbContext(DbContextOptions<RecrutmentDbContext> options)
            : base(options)
        { }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateSkill> CandidatesSkills { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobSkill> JobsSkills { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
