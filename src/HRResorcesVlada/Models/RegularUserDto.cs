using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class RegularUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserCity { get; set; }
        public string UserVilingToChangeLocation { get; set; }
        public string UserFullTimeJob { get; set; }
        public string UserWorkExperience { get; set; }
        public string UserKeyWords { get; set; }

        

        /*  public int NumberOfRegularUser { get

            {
                return RegularUserLA.Count;
            }

         }*/




        /* public string Education { get; set; }
         public string SchoolName { get; set; }
         public string SchoolCity { get; set; }
         public int Workexperience { get; set; }
         public string EnglishLenguageSkill { get; set; }*/


    }
}
