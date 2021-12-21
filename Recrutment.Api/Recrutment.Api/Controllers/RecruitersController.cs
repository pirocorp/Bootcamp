namespace Recrutment.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class RecruitersController : ApiController
    {
        private readonly IRecruitersService recruitersService;

        public RecruitersController(IRecruitersService recruitersService)
        {
            this.recruitersService = recruitersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int? level)
        {
            if (!level.HasValue)
            {
                return this.Ok(await this.recruitersService.GetAll());
            }

            return this.Ok(await this.recruitersService.GetByLevel(level.Value));
        }
    }
}
