namespace Recrutment.Api.Models.Jobs.JobApi
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Skills;

    public class JobApiModel : IMapFrom<Job>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public ICollection<SkillApiModel> Skills { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Job, JobApiModel>()
                .ForMember(
                    d => d.Skills,
                    opt => opt.MapFrom(s => s.Skills.Select(s => s.Skill)));
        }
    }
}
