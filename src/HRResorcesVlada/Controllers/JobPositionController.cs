using HRResorcesVlada.Models;
using Microsoft.AspNetCore.JsonPatch;
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

      /*  [HttpGet("id")]
        public IActionResult GetJobPosition(int id)
        {
            var jobPositionToReturn = JobPositionDataStore.Current.JobPositions.FirstOrDefault(c => c.Id == id);

            if (jobPositionToReturn == null)
            {
                return NotFound();

            }
            return Ok(jobPositionToReturn);
        }*/
     
       [HttpGet("{city}")]
        public IActionResult GetJobPositionscity(string city)
        {
            var jobPositionToReturn = JobPositionDataStore.Current.JobPositions.FindAll(c=>c.City==city);

            if (jobPositionToReturn.Count == 0)

            {

             var jobPositionToReturnKeyWords = JobPositionDataStore.Current.JobPositions.FindAll(c => c.Country == city);

             if (jobPositionToReturnKeyWords.Count == 0)

                {

               var jobPositionToReturnKeyWord = JobPositionDataStore.Current.JobPositions.FindAll(c => c.KeyWords == city);

               if (jobPositionToReturnKeyWord.Count == 0)

                    {

                   var jobPositionToReturnFullTime = JobPositionDataStore.Current.JobPositions.FindAll(c => c.PartTime == city);

                   if (jobPositionToReturnFullTime.Count == 0)

                        {
                            return NotFound();
                        }

                        return Ok(jobPositionToReturnFullTime);

                    }

                return Ok(jobPositionToReturnKeyWord);

                }

                return Ok(jobPositionToReturnKeyWords);
            }

            if (jobPositionToReturn.Count == 0)
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

        [HttpPut("{Id}")]
        public IActionResult UpdateJobPosition(int id,
     [FromBody] JobPositionForUpdateDto newJobPositionss)
        {
            if (newJobPositionss == null)

            {
                return BadRequest();
            }

            var JobPositionsFromStore = JobPositionDataStore.Current.JobPositions.FirstOrDefault(p =>p.Id==id);

            if (JobPositionsFromStore  == null)
            {
                return NotFound();
            }
            JobPositionsFromStore.Name = newJobPositionss.Name;
            JobPositionsFromStore.Description = newJobPositionss.Description;
            JobPositionsFromStore.City = newJobPositionss.City;
            JobPositionsFromStore.Country = newJobPositionss.Country;
            JobPositionsFromStore.PartTime = newJobPositionss.PartTime;
            JobPositionsFromStore.KeyWords = newJobPositionss.KeyWords;



            return NoContent();

        }
          [HttpPatch("{Id}")]
                public IActionResult UpdateJobPosition(int id,
                  [FromBody]JsonPatchDocument<JobPositionForUpdateDto> patchDoc)
                {
                    if (patchDoc == null)
                    {

                        BadRequest();
                    }
                    var JobPositionFromStore = JobPositionDataStore.Current.JobPositions.FirstOrDefault(p => p.Id == id);

                    if (JobPositionFromStore == null)
                    {
                        return NotFound();
                    }
                    var jobPositionToPatch = new JobPositionForUpdateDto()
                    {
                        Name = JobPositionFromStore.Name,
                        Description = JobPositionFromStore.Description,
                        City = JobPositionFromStore.City,
                        Country = JobPositionFromStore.Country,
                        PartTime = JobPositionFromStore.PartTime,
                        KeyWords = JobPositionFromStore.KeyWords

                    };

                    patchDoc.ApplyTo(jobPositionToPatch);

            JobPositionFromStore.Name =jobPositionToPatch.Name;
            JobPositionFromStore.Description = jobPositionToPatch.Description;
            JobPositionFromStore.City = jobPositionToPatch.City;
            JobPositionFromStore.PartTime = jobPositionToPatch.PartTime;
            JobPositionFromStore.KeyWords = jobPositionToPatch.KeyWords;
            JobPositionFromStore.Country = jobPositionToPatch.Country;
                  
                    return NoContent();
                }

          [HttpDelete("{Id}")]

        public IActionResult deliteJobposition(int id)
           
       
        {
            var JobPositionDelite = JobPositionDataStore.Current.JobPositions.FirstOrDefault(c =>c.Id == id);

            if (JobPositionDelite == null)
            {
                return NotFound();
            }

            JobPositionDataStore.Current.JobPositions.Remove(JobPositionDelite);

            return NoContent();
        }
    }
}
