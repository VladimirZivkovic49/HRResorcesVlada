using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Entities
{
    public class RegularUser
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string VilingToChangeLocation { get; set; }
        public string FullTimeJob { get; set; }
        public string WorkExperience { get; set; }
        public string KeyWords { get; set; }




    }
}
