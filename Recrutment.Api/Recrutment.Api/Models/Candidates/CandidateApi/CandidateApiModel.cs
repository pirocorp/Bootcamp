namespace Recrutment.Api.Models.Candidates.CandidateApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Skills;

    public class CandidateApiModel : IMapFrom<Candidate>, IHaveCustomMappings
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Bio { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public RecruiterApiModel Recruiter { get; set; }

        [Required]
        public ICollection<SkillApiModel> Skills { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Candidate, CandidateApiModel>()
                .ForMember(
                    cam => cam.Skills,
                    opt => opt.MapFrom(c => c.Skills.Select(cs => cs.Skill)));
        }
    }
}
