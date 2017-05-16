using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class CompanyDataStore
    {
        public static CompanyDataStore Current { get; } = new CompanyDataStore();
        public List<CompanyDto> Companies { get; set; }
        public string Company { get; set; }
        public CompanyDataStore()
        {
            Companies = new List<CompanyDto>()
            {

                new CompanyDto()
                {
            Id=1,
            Name="ABC",
            Description ="Hardware",
            City="Novi Sad",
            Country="Serbia",
            Phone="1111111",
            EmailAdress=" ABC@co",
            WebSite="www.ABC"

            },

                 new CompanyDto()
                {

             Id=2,
            Name="CDC",
            Description ="Software",
            City="Frankfurt",
            Country="Germany",
            Phone="2222222",
            EmailAdress=" CdC@co",
            WebSite="www.CDC"
                 }
             };
        }





    }
}
