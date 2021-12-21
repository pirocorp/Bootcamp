namespace Recrutment.Api.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Jobs.JobApi;

    public interface IJobsService
    {
        Task CreateJob(string title, string description, decimal salary, IEnumerable<int> skillIds);

        Task<IEnumerable<JobApiModel>> GetJobsBySkill(string jobName);

        Task DeleteJob(string id);
    }
}
