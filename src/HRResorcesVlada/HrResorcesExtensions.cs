using HRResorcesVlada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada
{
    public static class HrResorcesExtensions
    {

        public static void EnsureSeedDataForContext(this HrResorcesContext context)
        {
            if (context.Companies.Any())
            {
                return;
            }

           var companies= new List<Company>
            {

           new Company()

           {
            Name="ABC",
            Description ="Hardware",
            City="Novi Sad",
            Country="Serbia",
            Phone="1111111",
            EmailAdress=" ABC@co",
            WebSite="www.ABC",
            JobsPosition= new List<JobPosition>()
            {

            new JobPosition()
            {
           
            Name="Front end",
            Description ="Java",
            City="Novi Sad",
            Country="Serbia",
            PartTime="Da",
            KeyWords=" Iskustvo 5 god", }
            }
         },
   
       };

          if (context.RegularUsers.Any())
            {
                return;
            }

            var regularUsers = new List<RegularUser>()
            {

           new RegularUser()

           {
            Name="Vlada",
            Surname="Zivkovic",
            City="Novi Sad",
            VilingToChangeLocation="Da",
            FullTimeJob="Da",
            WorkExperience=" Da",
            KeyWords="Hemičar"
           },

           
            
            
            };






            context.Companies.AddRange(companies);
            context.RegularUsers.AddRange(regularUsers);

            context.SaveChanges();

        }

    }
}
