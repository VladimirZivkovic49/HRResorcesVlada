using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class RegularUserDataStore
    {
        public static RegularUserDataStore Current { get; } = new RegularUserDataStore();
        public List<RegularUserDto> RegularUsers { get; set; }

        public string  RegularUser { get; set; }
        public RegularUserDataStore()
        {
            RegularUsers = new List<RegularUserDto>()
            {


                new RegularUserDto()
                {
            UserId=1,
            UserName="Vlada",
            UserSurname="Zivkovic",
            UserCity="Novi Sad",
            UserVilingToChangeLocation="Da",
            UserFullTimeJob="Da",
            UserWorkExperience=" Da",
            UserKeyWords="Hemičar"

            },

                 new RegularUserDto()
                {

            UserId =2,
            UserName="Pera",
            UserSurname="Petrović",
            UserCity="Beograd",
            UserVilingToChangeLocation="Ne",
            UserFullTimeJob="Da",
            UserWorkExperience=" Da",
            UserKeyWords="Električar"
                 }
             };
        }
    }
}         

            
            

