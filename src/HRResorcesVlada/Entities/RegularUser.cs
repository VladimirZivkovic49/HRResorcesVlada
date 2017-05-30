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

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserCity { get; set; }
        public string UserVilingToChangeLocation { get; set; }
        public string UserFullTimeJob { get; set; }
        public string UserWorkExperience { get; set; }
        public string UserKeyWords { get; set; }




    }
}
