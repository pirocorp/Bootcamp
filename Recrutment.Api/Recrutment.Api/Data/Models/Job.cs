namespace Recrutment.Api.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Job
    {
        public Job()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Skills = new List<JobSkill>();
            this.Interviews = new List<Interview>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Salary { get; set; }

        public ICollection<JobSkill> Skills { get; set; }

        public ICollection<Interview> Interviews { get; set; }
    }
}
