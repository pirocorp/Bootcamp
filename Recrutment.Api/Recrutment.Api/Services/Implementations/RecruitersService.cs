namespace Recrutment.Api.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models.Candidates.CandidateApi;
    using Models.Recruiters;
    using static ApiConstants.Recruiter;

    public class RecruitersService : IRecruitersService
    {
        private readonly RecrutmentDbContext dbContext;

        public RecruitersService(RecrutmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> CreateRecruiterIfNotExists(RecruiterApiModel model)
        {
            var existingRecruiter = await this.dbContext.Recruiters
                .FirstOrDefaultAsync(r => r.Email.Equals(model.Email));

            if (existingRecruiter is not null)
            {
                return existingRecruiter.Id;
            }

            var recruiter = new Recruiter()
            {
                Country = model.Country,
                Email = model.Email,
                LastName = model.LastName,
            };

            await this.dbContext.AddAsync(recruiter);
            await this.dbContext.SaveChangesAsync();

            return recruiter.Id;
        }

        public async Task<IEnumerable<RecruiterApiResponseModel>> GetAll()
            => await this.dbContext.Recruiters
                .Where(r => r.Candidates.Any())
                .To<RecruiterApiResponseModel>()
                .ToListAsync();

        public async Task<IEnumerable<RecruiterApiResponseModel>> GetByLevel(int level)
            => await this.dbContext.Recruiters
                .Where(r => r.Level == level)
                .To<RecruiterApiResponseModel>()
                .ToListAsync();

        public async Task<bool> RecruiterHasFreeSlot(string recruiterId)
            => await this.dbContext.Recruiters
                .Where(r => r.Id.Equals(recruiterId))
                .AnyAsync(r => r.Candidates.Count < RecruiterFreeSlots);

        public async Task IncreaseRecruiterLevel(string recruiterId)
        {
            var recruiter = await this.dbContext.Recruiters.FindAsync(recruiterId);

            recruiter.Level += 1;

            this.dbContext.Attach(recruiter);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DecreaseRecruiterLevel(string recruiterId)
        {
            var recruiter = await this.dbContext.Recruiters.FindAsync(recruiterId);

            recruiter.Level -= 1;

            this.dbContext.Attach(recruiter);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
