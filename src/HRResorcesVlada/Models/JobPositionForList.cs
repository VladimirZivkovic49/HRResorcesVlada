using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class JobPositionForList
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public string JobCity { get; set; }
        public string JobCountry { get; set; }
        public string JobPartTime { get; set; }
        public string JobKeyWords { get; set; }

        public string CompanyName { get; set; }


    }
}
