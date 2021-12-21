namespace Recrutment.Api.Controllers
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    using static ApiConstants;
    using static ApiConstants.SkillsEndpoints;

    public class SkillsController : ApiController
    {
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.skillsService.GetSkill(id));

        [HttpGet(Active)]
        public async Task<IActionResult> GetActive()
            => this.Ok(await this.skillsService.ActiveSkills());
    }
}
