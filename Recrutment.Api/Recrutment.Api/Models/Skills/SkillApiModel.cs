namespace Recrutment.Api.Models.Skills
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class SkillApiModel : IMapFrom<Skill>
    {
        [Required]
        public string Name { get; set; }
    }
}
