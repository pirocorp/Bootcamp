namespace Recrutment.Api.Models.Candidates.CandidateApi
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class RecruiterApiModel : IMapFrom<Recruiter>
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
