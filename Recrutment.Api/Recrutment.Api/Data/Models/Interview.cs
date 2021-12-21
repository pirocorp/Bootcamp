namespace Recrutment.Api.Data.Models
{
    public class Interview
    {
        public string JobId { get; set; }

        public Job Job { get; set; }

        public string RecruiterId { get; set; }

        public Recruiter Recruiter { get; set; }

        public string CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
