namespace Recrutment.Api.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Candidates.CandidateApi;
    using Models.Recruiters;

    public interface IRecruitersService
    {
        Task<string> CreateRecruiterIfNotExists(RecruiterApiModel recruiter);

        Task<IEnumerable<RecruiterApiResponseModel>> GetAll();

        Task<IEnumerable<RecruiterApiResponseModel>> GetByLevel(int level);

        Task<bool> RecruiterHasFreeSlot(string recruiterId);

        Task IncreaseRecruiterLevel(string recruiterId);

        Task DecreaseRecruiterLevel(string recruiterId);
    }
}
