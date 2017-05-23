using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Entities
{
    public class Company

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string EmailAdress { get; set; }
        public string WebSite { get; set; }

        public ICollection<JobPosition> JobsPosition { get; set; } =
            new List<JobPosition>();

    }
}
