namespace Recrutment.Api.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Candidates.CandidateApi;

    public interface ICandidatesService
    {
        Task<CandidateApiModel> GetCandidate(string id);

        Task CreateCandidate(
            string firstName,
            string lastName,
            string email,
            string bio,
            DateTime birthDate,
            IEnumerable<int> skillIds,
            string recruiterId);

        Task UpdateCandidate(
            string candidateId,
            string firstName,
            string lastName,
            string email,
            string bio,
            DateTime birthDate,
            IEnumerable<int> skillIds,
            string recruiterId);

        Task DeleteCandidate(string candidateId);
    }
}
