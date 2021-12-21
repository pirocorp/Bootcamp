namespace Recrutment.Api.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Candidates.CandidateApi;
    using Services;

    using static ApiConstants;

    public class CandidatesController : ApiController
    {
        private readonly ISkillsService skillsService;
        private readonly IRecruitersService recruitersService;
        private readonly ICandidatesService candidatesService;

        public CandidatesController(
            ISkillsService skillsService,
            IRecruitersService recruitersService,
            ICandidatesService candidatesService)
        {
            this.skillsService = skillsService;
            this.recruitersService = recruitersService;
            this.candidatesService = candidatesService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(string id)
            => this.OkOrNotFound(await this.candidatesService.GetCandidate(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateApiModel model)
        {
            var skillIds = await this.skillsService.EnsureSkillsExists(model.Skills.Select(s => s.Name));
            var recruiterId = await this.recruitersService.CreateRecruiterIfNotExists(model.Recruiter);

            if (await this.recruitersService.RecruiterHasFreeSlot(recruiterId))
            {
                await this.candidatesService.CreateCandidate(
                    model.FirstName,
                    model.LastName,
                    model.Email,
                    model.Bio,
                    model.BirthDate,
                    skillIds,
                    recruiterId);

                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpPut(WithId)]
        public async Task<IActionResult> Put([FromBody] CandidateApiModel model, string id)
        {
            var skillIds = await this.skillsService.EnsureSkillsExists(model.Skills.Select(s => s.Name));
            var recruiterId = await this.recruitersService.CreateRecruiterIfNotExists(model.Recruiter);

            if (await this.recruitersService.RecruiterHasFreeSlot(recruiterId))
            {
                await this.candidatesService.UpdateCandidate(
                    id,
                    model.FirstName,
                    model.LastName,
                    model.Email,
                    model.Bio,
                    model.BirthDate,
                    skillIds,
                    recruiterId);

                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpDelete(WithId)]
        public async Task Delete(string id)
            => await this.candidatesService.DeleteCandidate(id);
    }
}
