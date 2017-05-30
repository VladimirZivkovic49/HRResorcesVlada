using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Models
{
    public class JobPositionDataStore
    {
        public static JobPositionDataStore Current { get; } = new JobPositionDataStore();
        public List<JobPositionDto> JobPositions { get; set; }
        public string JobPosition { get; set; }
        public JobPositionDataStore()
        {
            JobPositions = new List<JobPositionDto>()
            {

                new JobPositionDto()
                {
            JobId=1,
            JobName="Back end",
            JobDescription ="Java",
            JobCity="Novi Sad",
            JobCountry="Serbia",
            JobPartTime="Part time",
            JobKeyWords="Iskustvo 5 god",


            },

                 new JobPositionDto()
                {

            JobId=2,
            JobName="Front end",
            JobDescription ="C sharp",
            JobCity="Atina",
            JobCountry="Greace",
            JobPartTime="Full time",
            JobKeyWords="Iskustvo 1 god"


            },

                new JobPositionDto()
                {

            JobId=3,
            JobName="Back end",
            JobDescription ="Java",
            JobCity="Atina",
            JobCountry="Greace",
            JobPartTime="Part time",
            JobKeyWords="Iskustvo 1 god"

                },



            };
        }
    }
}



    