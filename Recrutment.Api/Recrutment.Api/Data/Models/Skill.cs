namespace Recrutment.Api.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Skill
    {
        public Skill()
        {
            this.Candidates = new List<CandidateSkill>();
            this.Jobs = new List<JobSkill>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CandidateSkill> Candidates { get; set; }

        public ICollection<JobSkill> Jobs { get; set; }
    }
}
