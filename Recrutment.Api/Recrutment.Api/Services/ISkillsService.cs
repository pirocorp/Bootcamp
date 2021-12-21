namespace Recrutment.Api.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Candidates.CandidateApi;
    using Models.Skills;

    public interface ISkillsService
    {
        Task<SkillApiModel> GetSkill(int id);

        Task<IEnumerable<SkillApiModel>> ActiveSkills();

        Task<IEnumerable<int>> EnsureSkillsExists(IEnumerable<string> skills);
    }
}
