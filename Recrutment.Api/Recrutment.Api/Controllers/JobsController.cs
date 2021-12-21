namespace Recrutment.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models.Jobs.JobApi;
    using Services;

    using static ApiConstants;

    public class JobsController : ApiController
    {
        private readonly ISkillsService skillsService;
        private readonly IJobsService jobsService;

        public JobsController(
            ISkillsService skillsService,
            IJobsService jobsService)
        {
            this.skillsService = skillsService;
            this.jobsService = jobsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string skill)
            => this.Ok(await this.jobsService.GetJobsBySkill(skill));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobApiModel model)
        {
            var skillIds = await this.skillsService.EnsureSkillsExists(model.Skills.Select(s => s.Name));

            await this.jobsService.CreateJob(
                model.Title,
                model.Description,
                model.Salary,
                skillIds);

            return this.Ok();
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.jobsService.DeleteJob(id);

            return this.Ok();
        }
    }
}
