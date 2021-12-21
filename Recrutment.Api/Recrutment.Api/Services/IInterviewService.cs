namespace Recrutment.Api.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Interviews;

    public interface IInterviewService
    {
        Task<IEnumerable<InterviewApiModel>> GetAll();
    }
}
