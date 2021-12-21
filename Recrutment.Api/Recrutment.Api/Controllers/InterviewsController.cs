namespace Recrutment.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class InterviewsController : ApiController
    {
        private readonly IInterviewService interviewService;

        public InterviewsController(IInterviewService interviewService)
        {
            this.interviewService = interviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => this.Ok(await this.interviewService.GetAll());
    }
}
