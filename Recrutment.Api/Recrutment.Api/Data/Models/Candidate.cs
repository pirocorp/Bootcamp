namespace Recrutment.Api.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Candidate
    {
        public Candidate()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Skills = new List<CandidateSkill>();
            this.Interviews = new List<Interview>();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Bio { get; set; }

        public DateTime BirthDate { get; set; }

        public string RecruiterId { get; set; }

        public Recruiter Recruiter { get; set; }

        public ICollection<CandidateSkill> Skills { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
