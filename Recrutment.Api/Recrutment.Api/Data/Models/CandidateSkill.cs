namespace Recrutment.Api.Data.Models
{
    public class CandidateSkill
    {
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public string CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
