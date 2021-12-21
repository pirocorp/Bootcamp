namespace Recrutment.Api.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models.Candidates.CandidateApi;
    using Models.Skills;

    public class SkillsService : ISkillsService
    {
        private readonly RecrutmentDbContext dbContext;

        public SkillsService(RecrutmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SkillApiModel> GetSkill(int id)
            => await this.dbContext.Skills
                .Where(s => s.Id.Equals(id))
                .To<SkillApiModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<SkillApiModel>> ActiveSkills()
            => await this.dbContext.Skills
                .Where(s => s.Candidates.Any())
                .To<SkillApiModel>()
                .ToListAsync();

        public async Task<IEnumerable<int>> EnsureSkillsExists(IEnumerable<string> skills)
        {
            var alreadyExistingSkills = await this.dbContext.Skills
                .Where(s => skills.Any(x => s.Name.Equals(x)))
                .ToListAsync();

            var missingSkills = new List<Skill>();

            foreach (var skill in skills)
            {
                if (alreadyExistingSkills.Any(x => x.Name.Equals(skill, StringComparison.InvariantCultureIgnoreCase)))
                {
                    continue;
                }

                var newSkill = new Skill()
                {
                    Name = skill
                };

                missingSkills.Add(newSkill);
            }

            await this.dbContext.AddRangeAsync(missingSkills);
            await this.dbContext.SaveChangesAsync();

            return missingSkills.Union(alreadyExistingSkills)
                .Select(s => s.Id)
                .ToList();
        }
    }
}
