namespace Recrutment.Api.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Infrastructure.AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models.Interviews;

    public class InterviewService : IInterviewService
    {
        private readonly RecrutmentDbContext dbContext;

        public InterviewService(RecrutmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<InterviewApiModel>> GetAll()
            => await this.dbContext.Interviews
                .To<InterviewApiModel>()
                .ToListAsync();
    }
}
