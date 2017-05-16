using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class JobPositionForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PartTime { get; set; }
        public string KeyWords { get; set; }
    }
}
