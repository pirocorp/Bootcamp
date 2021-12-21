namespace Recrutment.Api.Models.Recruiters
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class RecruiterApiResponseModel : IMapFrom<Recruiter>
    {
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public int Level { get; set; }
    }
}
