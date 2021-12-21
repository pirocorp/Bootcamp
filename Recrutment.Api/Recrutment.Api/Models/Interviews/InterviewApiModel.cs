namespace Recrutment.Api.Models.Interviews
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class InterviewApiModel : IMapFrom<Interview>
    {
        public string JobTitle { get; set; }

        public string RecruiterLastName { get; set; }

        public string CandidateEmail { get; set; }
    }
}
