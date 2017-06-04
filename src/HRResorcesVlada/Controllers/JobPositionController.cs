using AutoMapper;
using HRResorcesVlada.Models;
using HRResorcesVlada.Services;
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
        private HrResorcesInterface _hrResorcesInterface;

               public JobPositionController(HrResorcesInterface hrResorcesInterface)
               {
                   _hrResorcesInterface = hrResorcesInterface;
               }





        [HttpGet()]
        public IActionResult GetJobPisitions()

        {
             var jobPositionEntities = _hrResorcesInterface.GetJobPositions();
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionEntities);
            return Ok(results);

        }
        [HttpGet("name/{name}")]
        public IActionResult GetJobPositionName(string name)
        {
            if (name == null)

            {
                return BadRequest();
            }
            var jobPositionName = _hrResorcesInterface.GetJobPositionsName(name);
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionName);
            int proba = results.Count();
            if (proba == 0)
            {
                return NotFound();
            }

            return Ok(results);

        }
        [HttpGet("description/{description}")]
        public IActionResult GetJobPositionDescription(string description)

        {
            if (description == null)

            {
                return BadRequest();

            }
            var jobPositionDesription = _hrResorcesInterface.GetJobPositionsDescription(description);
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionDesription);
            int proba = results.Count();

            if (proba == 0)
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpGet("city/{city}")]
        public IActionResult GetJobPositionGrad(string city)
        {

            if (city == null)

            {
                return BadRequest();

            }
            var jobPositionGrad = _hrResorcesInterface.GetJobPositionsGrad(city);
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionGrad);
            int proba = results.Count();
            if (proba == 0)
            {
                return NotFound();
            }

            return Ok(results);


        }
        [HttpGet("country/{country}")]
        public IActionResult GetJobPositionDrzava(string country)
        {

            if (country == null)

            {
                return BadRequest();

            }

            var jobPositionDrzava = _hrResorcesInterface.GetJobPositionsDrzava(country);
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionDrzava);
            int proba = results.Count();

            if (proba == 0)
            {
                return NotFound();
            }
            return Ok(results);
        }
        [HttpGet("parttime/{parttime}")]
        public IActionResult GetJobPositionParTime(string parttime)
        {

            if (parttime == null)

            {
                return BadRequest();

            }
            var jobPositionPartTime = _hrResorcesInterface.GetJobPositionsParTime(parttime);
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionPartTime);
            int proba = results.Count();
            if (proba == 0)
            {

                return NotFound();
            }

            return Ok(results);

        }
        [HttpGet("keywords/{keywords}")]
        public IActionResult GetJobPositionKljRe(string keywords)
        {

            if (keywords == null)

            {
                return BadRequest();

            }
            var jobPositionKljRe = _hrResorcesInterface.GetJobPositionsKljRe(keywords);
            var results = Mapper.Map<IEnumerable<JobPositionForList>>(jobPositionKljRe);
            int proba = results.Count();


            if (proba == 0)
            {
                return NotFound();

            }
            return Ok(results);




        }
      
        
        
        

            





            /*  var jobPositionToReturn = JobPositionDataStore.Current.JobPositions.FindAll(c=>c.JobCity==city);

                            if (jobPositionToReturn.Count == 0)

                            {

                             var jobPositionToReturnKeyWords = JobPositionDataStore.Current.JobPositions.FindAll(c => c.JobCountry == city);

                             if (jobPositionToReturnKeyWords.Count == 0)

                                {

                               var jobPositionToReturnKeyWord = JobPositionDataStore.Current.JobPositions.FindAll(c => c.JobKeyWords == city);

                               if (jobPositionToReturnKeyWord.Count == 0)

                                    {

                                   var jobPositionToReturnFullTime = JobPositionDataStore.Current.JobPositions.FindAll(c => c.JobPartTime == city);

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

                            }*/





        [HttpPost("{CompanyName}")]
        public IActionResult CreateNewJobPosition(string CompanyName, [FromBody] JobPositionForCreationDto newJobPositionss)

                {
                    if (newJobPositionss == null)

                    {
                        return BadRequest();
                    }

            string companyName = CompanyName;

            if (!_hrResorcesInterface.CompanyExists(companyName))
            {
                return BadRequest("Ne Postoji Kompanija  pod tim imenom");

            }


            /*  string jobPositionName = newJobPositionss.JobName;

     if (_hrResorcesInterface.Exists(jobPositionName))
     {
         return BadRequest("Postoji Pozicija  pod tim imenom");

     }*/

            var finalJobPosition = Mapper.Map<Entities.JobPosition>(newJobPositionss);

           _hrResorcesInterface.AddNewJobPosition(finalJobPosition);

           if (!_hrResorcesInterface.Save())

           {
               return StatusCode(500, "nije sačuvano");
           }





           return CreatedAtRoute(new
           { }, finalJobPosition);





            // var JobPositionss = JobPositionDataStore.Current.JobPositions;










            /* if (JobPositionss == null)
                     {
                         return NotFound();
                     }

                     var maxJobPositionsId = JobPositionDataStore.Current.JobPositions.Max(c => c.JobId);

                     var finalJobPosition = new JobPositionDto()
                     {
                         JobId = ++ maxJobPositionsId,
                         JobName = newJobPositionss.JobName,
                        JobDescription = newJobPositionss.JobDescription,
                         JobCity = newJobPositionss.JobCity,
                        JobCountry = newJobPositionss.JobCountry,
                         JobPartTime = newJobPositionss.JobPartTime,
                        JobKeyWords = newJobPositionss.JobKeyWords,


                     };
                     JobPositionss.Add(finalJobPosition);*/


            /*   return CreatedAtRoute( new
                       { }, finalJobPosition);*/
        }

        /*   [HttpPut("{Id}")]
           public IActionResult UpdateJobPosition(int id,
        [FromBody] JobPositionForUpdateDto newJobPositionss)
           {
               if (newJobPositionss == null)

               {
                   return BadRequest();
               }

               var JobPositionsFromStore = JobPositionDataStore.Current.JobPositions.FirstOrDefault(p =>p.JobId==id);

               if (JobPositionsFromStore  == null)
               {
                   return NotFound();
               }
               JobPositionsFromStore.JobName = newJobPositionss.JobName;
               JobPositionsFromStore.JobDescription = newJobPositionss.JobDescription;
               JobPositionsFromStore.JobCity = newJobPositionss.JobCity;
               JobPositionsFromStore.JobCountry = newJobPositionss.JobCountry;
               JobPositionsFromStore.JobPartTime = newJobPositionss.JobPartTime;
               JobPositionsFromStore.JobKeyWords = newJobPositionss.JobKeyWords;



               return NoContent();

           }*/
        [HttpPatch("{Id}")]
                public IActionResult UpdateJobPosition(int id,
                  [FromBody]JsonPatchDocument<JobPositionForUpdateDto> patchDoc)
                {
                    if (patchDoc == null)
                    {

                        BadRequest();
                    }

               if (!_hrResorcesInterface.JobPositionExists(id))
               {
             return NotFound("Ne postoji Pozicija   pod tim Id");

              }

         var jobPositionEntity = _hrResorcesInterface.GetJobPositio(id);

              if (jobPositionEntity == null)

                    {
                  return NotFound();

                    }


                    var jobPositionToPatch = Mapper.Map<JobPositionForUpdateDto>(jobPositionEntity);

                   patchDoc.ApplyTo(jobPositionToPatch, ModelState);

                  if (!ModelState.IsValid)

                   {

                return BadRequest(ModelState);

                   }


                        TryValidateModel(jobPositionToPatch);

                       if (!ModelState.IsValid)

                        {

                      return BadRequest(ModelState);

                        }

                      Mapper.Map(jobPositionToPatch, jobPositionEntity);



                       if (!_hrResorcesInterface.Save())

                      {

                      return StatusCode(500, "nije sačuvano");

                       }

            /*  var JobPositionFromStore = JobPositionDataStore.Current.JobPositions.FirstOrDefault(p => p.JobId == id);

            if (JobPositionFromStore == null)
            {
                return NotFound();
            }
            var jobPositionToPatch = new JobPositionForUpdateDto()
            {
                JobName = JobPositionFromStore.JobName,
                JobDescription = JobPositionFromStore.JobDescription,
                JobCity = JobPositionFromStore.JobCity,
                JobCountry = JobPositionFromStore.JobCountry,
                JobPartTime = JobPositionFromStore.JobPartTime,
                JobKeyWords = JobPositionFromStore.JobKeyWords

            };

            patchDoc.ApplyTo(jobPositionToPatch);

    JobPositionFromStore.JobName =jobPositionToPatch.JobName;
    JobPositionFromStore.JobDescription = jobPositionToPatch.JobDescription;
    JobPositionFromStore.JobCity = jobPositionToPatch.JobCity;
    JobPositionFromStore.JobPartTime = jobPositionToPatch.JobPartTime;
    JobPositionFromStore.JobKeyWords = jobPositionToPatch.JobKeyWords;
    JobPositionFromStore.JobCountry = jobPositionToPatch.JobCountry;*/

            return NoContent();
                }

          [HttpDelete("{Id}")]

        public IActionResult deliteJobposition(int id)
           
       
        {
               if (!_hrResorcesInterface.JobPositionExists(id))
              {
                  return NotFound("Ne postoji Pozicija  pod tim Id");

              }

              var jobPositionDelite = _hrResorcesInterface.GetJobPositio(id);

              if (jobPositionDelite == null)
              {

                  return NotFound();
              }

             _hrResorcesInterface.DeliteJobPosition(jobPositionDelite);

              if (!_hrResorcesInterface.Save())
              {

                  return StatusCode(500, "nije sačuvano");
              }

              return NoContent();














            /* var JobPositionDelite = JobPositionDataStore.Current.JobPositions.FirstOrDefault(c =>c.JobId == id);

            if (JobPositionDelite == null)
            {
                return NotFound();
            }

            JobPositionDataStore.Current.JobPositions.Remove(JobPositionDelite);

            return NoContent();*/
        }
    }
}
