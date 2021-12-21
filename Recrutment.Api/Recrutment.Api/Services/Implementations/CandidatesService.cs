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

    public class CandidatesService : ICandidatesService
    {
        private readonly RecrutmentDbContext dbContext;
        private readonly IRecruitersService recruitersService;

        public CandidatesService(
            RecrutmentDbContext dbContext,
            IRecruitersService recruitersService
            )
        {
            this.dbContext = dbContext;
            this.recruitersService = recruitersService;
        }

        public async Task<CandidateApiModel> GetCandidate(string id)
            => await this.dbContext.Candidates
                .Where(c => c.Id.Equals(id))
                .To<CandidateApiModel>()
                .FirstOrDefaultAsync();

        public async Task CreateCandidate(
            string firstName, 
            string lastName, 
            string email, 
            string bio, 
            DateTime birthDate,
            IEnumerable<int> skillIds, 
            string recruiterId)
        {
            var candidate = new Candidate()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Bio = bio,
                BirthDate = birthDate,
                RecruiterId = recruiterId
            };

            await this.dbContext.AddAsync(candidate);
            await this.dbContext.SaveChangesAsync();

            await this.recruitersService.IncreaseRecruiterLevel(recruiterId);

            await this.ApplyCandidateSkills(skillIds, candidate);
        }

        public async Task UpdateCandidate(
            string candidateId,
            string firstName, 
            string lastName, 
            string email, 
            string bio, 
            DateTime birthDate,
            IEnumerable<int> skillIds, 
            string recruiterId)
        {
            var candidate = await this.dbContext.Candidates
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id.Equals(candidateId));

            if (candidate.RecruiterId != recruiterId)
            {
                await this.recruitersService.IncreaseRecruiterLevel(recruiterId);
                await this.recruitersService.DecreaseRecruiterLevel(candidate.RecruiterId);
            }

            candidate.FirstName = firstName;
            candidate.LastName = lastName;
            candidate.Email = email;
            candidate.Bio = bio;
            candidate.BirthDate = birthDate;
            candidate.RecruiterId = recruiterId;

            this.dbContext.CandidatesSkills.RemoveRange(candidate.Skills);
            await this.dbContext.SaveChangesAsync();

            candidate.Skills = new List<CandidateSkill>();

            this.dbContext.Attach(candidate);
            await this.dbContext.SaveChangesAsync();

            await ApplyCandidateSkills(skillIds, candidate);
        }

        public async Task DeleteCandidate(string candidateId)
        {
            var candidate = await this.dbContext.Candidates
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id.Equals(candidateId));

            var interviews = await this.dbContext.Interviews
                .Where(i => i.CandidateId == candidateId)
                .ToListAsync();

            this.dbContext.RemoveRange(interviews);
            this.dbContext.RemoveRange(candidate.Skills);
            this.dbContext.Candidates.Remove(candidate);

            await  this.dbContext.SaveChangesAsync();
        }

        private async Task ApplyCandidateSkills(IEnumerable<int> skillIds, Candidate candidate)
        {
            var candidateSkills = skillIds.Select(si => new CandidateSkill()
            {
                SkillId = si,
                CandidateId = candidate.Id
            }).ToList();

            await this.dbContext.AddRangeAsync(candidateSkills);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
