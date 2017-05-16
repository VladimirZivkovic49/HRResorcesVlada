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
            Id=1,
            Name="Front end",
            Description ="Java",
            City="Novi Sad",
            Country="Serbia",
            PartTime="Da",
            KeyWords=" Iskustvo 5 god",


            },

                 new JobPositionDto()
                {

            Id=2,
            Name="Back end",
            Description ="C#",
            City="Atina",
            Country="Greace",
            PartTime="Ne",
            KeyWords=" Iskustvo 1 god",
                 }
             };
        }
    }
}



    