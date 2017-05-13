using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class RegularUserDto
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string VilingToChangeLocation { get; set; }
        public string FullTimeJob { get; set; }
        public string WorkExperience { get; set; }
        public string KeyWords { get; set; }


        /* public string Education { get; set; }
         public string SchoolName { get; set; }
         public string SchoolCity { get; set; }
         public int Workexperience { get; set; }
         public string EnglishLenguageSkill { get; set; }*/


    }
}
