namespace Recrutment.Api.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models.Jobs.JobApi;

    using static ApiConstants.Recruiter;

    public class JobsService : IJobsService
    {
        private readonly RecrutmentDbContext dbContext;
        private readonly IRecruitersService recruiterService;

        public JobsService(
            RecrutmentDbContext dbContext,
            IRecruitersService recruiterService)
        {
            this.dbContext = dbContext;
            this.recruiterService = recruiterService;
        }

        public async Task CreateJob(string title, string description, decimal salary, IEnumerable<int> skillIds)
        {
            var job = new Job()
            {
                Title = title,
                Description = description,
                Salary = salary
            };

            await this.dbContext.AddAsync(job);
            await this.dbContext.SaveChangesAsync();

            await this.ApplyJobSkills(skillIds, job);
            await this.CreateInterviews(skillIds, job.Id);
        }

        public async Task<IEnumerable<JobApiModel>> GetJobsBySkill(string skillName)
            => await this.dbContext.Jobs
                .Where(j => j.Skills.Any(s => s.Skill.Name.Equals(skillName)))
                .To<JobApiModel>()
                .ToListAsync();

        public async Task DeleteJob(string id)
        {
            var job = await this.dbContext.Jobs
                .Include(j => j.Skills)
                .Where(j => j.Id.Equals(id))
                .FirstOrDefaultAsync();

            var interviews = await this.dbContext.Interviews
                .Where(i => i.JobId == id)
                .ToListAsync();

            this.dbContext.RemoveRange(interviews);
            this.dbContext.RemoveRange(job.Skills);
            this.dbContext.Remove(job);

            await this.dbContext.SaveChangesAsync();
        }

        private async Task ApplyJobSkills(IEnumerable<int> skillIds, Job job)
        {
            var candidateSkills = skillIds.Select(si => new JobSkill()
            {
                SkillId = si,
                JobId = job.Id
            }).ToList();

            await this.dbContext.AddRangeAsync(candidateSkills);
            await this.dbContext.SaveChangesAsync();
        }

        private async Task CreateInterviews(IEnumerable<int> skillIds, string jobId)
        {
            var validSkills = skillIds.ToList();

            var suitableCandidates = await this.dbContext.Candidates
                .Where(c =>
                    c.Skills.Any(s => validSkills.Contains(s.Skill.Id))
                    && c.Recruiter.Candidates.Count < RecruiterFreeSlots)
                .Distinct()
                .ToListAsync();

            foreach (var suitableCandidate in suitableCandidates)
            {
                await this.recruiterService.IncreaseRecruiterLevel(suitableCandidate.RecruiterId);
            }

            var interviews = new List<Interview>();

            foreach (var suitableCandidate in suitableCandidates)
            {
                var interview = new Interview()
                {
                    JobId = jobId,
                    CandidateId = suitableCandidate.Id,
                    RecruiterId = suitableCandidate.RecruiterId
                };

                interviews.Add(interview);
            }

            await this.dbContext.AddRangeAsync(interviews);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
