using HRResorcesVlada.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Controllers
{

    [Route("api/jobs")]
    public class JobPositionController : Controller
    {

           [HttpGet()]
        public IActionResult GetJobPisitions()

        {

            return Ok(JobPositionDataStore.Current.JobPositions);

        }
          [HttpGet("{id}")]
        public IActionResult GetJobPosition(int id)
        {
            var jobPositionToReturn = JobPositionDataStore.Current.JobPositions.FirstOrDefault(c => c.Id==id);
           
            if (jobPositionToReturn == null)
            {
                return NotFound();

            }
            return Ok(jobPositionToReturn);
                
        }








        [HttpPost()]
        public IActionResult CreateNewJobPosition(int Id, [FromBody] JobPositionForCreationDto newJobPositionss)

                {
                    if (newJobPositionss == null)

                    {
                        return BadRequest();
                    }
                    var JobPositionss = JobPositionDataStore.Current.JobPositions;

                    if (JobPositionss == null)
                    {
                        return NotFound();
                    }

                    var maxJobPositionsId = JobPositionDataStore.Current.JobPositions.Max(c => c.Id);

                    var finalJobPosition = new JobPositionDto()
                    {
                        Id = ++ maxJobPositionsId,
                        Name = newJobPositionss.Name,
                       Description = newJobPositionss.Description,
                        City = newJobPositionss.City,
                       Country = newJobPositionss.Country,
                        PartTime = newJobPositionss.PartTime,
                       KeyWords = newJobPositionss.KeyWords,
                       

                    };
                    JobPositionss.Add(finalJobPosition);


                    return CreatedAtRoute( new
                    { }, finalJobPosition);
                }


    }
}
