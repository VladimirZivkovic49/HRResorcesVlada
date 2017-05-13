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

        public RegularUserDataStore()
        {
            RegularUsers = new List<RegularUserDto>()
            {

                new RegularUserDto()
                {
            Id=1,
            Name="Vlada",
            Surname="Zivkovic",
            City="Novi Sad",
            VilingToChangeLocation="Da",
            FullTimeJob="Da",
            WorkExperience=" Da",
            KeyWords="Hemičar"

            },

                 new RegularUserDto()
                {

            Id =2,
            Name="Pera",
            Surname="Petrović",
            City="Beograd",
            VilingToChangeLocation="Ne",
            FullTimeJob="Da",
            WorkExperience=" Da",
            KeyWords="Električar"
                 }
             };
        }
    }
}         

            
            

