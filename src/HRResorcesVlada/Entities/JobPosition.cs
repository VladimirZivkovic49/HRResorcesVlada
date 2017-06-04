using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Entities
{
    public class JobPosition
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobCity { get; set; }
        public string JobCountry { get; set; }
        public string JobPartTime { get; set; }
        public string JobKeyWords { get; set; }

        [ForeignKey("CompanyName")]
       // public Company Company { get; set; }

        public string CompanyName { get; set; }

    }
}
