namespace Recrutment.Api.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Recruiter
    {
        public Recruiter()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Candidates = new List<Candidate>();
            this.Interviews = new List<Interview>();
        }

        public string Id { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public int Level { get; set; }

        public ICollection<Candidate> Candidates { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
