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
    [Route("api/regular")]

    public class RegularUserController : Controller
    {
        private HrResorcesInterface _hrResorcesInterface;

        public RegularUserController(HrResorcesInterface hrResorcesInterface)
        {
            _hrResorcesInterface = hrResorcesInterface;
        }

        [HttpGet()]
        public IActionResult GetRegularUsers()
        { 
         var regularuserEntities = _hrResorcesInterface.GetRegularUsers();
         var results = Mapper.Map<IEnumerable<RegularUserForList>>(regularuserEntities);

       

            return Ok(results);

        }

        [HttpGet("{id}")]
        public IActionResult GetRegularUser(int id)
        {
            var regularUserToReturn = RegularUserDataStore.Current.RegularUsers.FirstOrDefault(c => c.UserId == id);

            if (regularUserToReturn == null)
            {
                return NotFound();

            }
            return Ok(regularUserToReturn);

        }



        [HttpPost()]
        public IActionResult CreateNewRegularUser(int Id, [FromBody] RegularUserForCreationDto newRegularUserss)

        {
            if (newRegularUserss == null)

            {
                return BadRequest();
            }
            var RegularUserss = RegularUserDataStore.Current.RegularUsers;

            if (RegularUserss == null)
            {
                return NotFound();
            }

            var maxRegularUsersId = RegularUserDataStore.Current.RegularUsers.Max(c => c.UserId);

            var finalRegularuser = new RegularUserDto()
            {
                UserId = ++maxRegularUsersId,
                UserName = newRegularUserss.UserName,
                UserSurname = newRegularUserss.UserSurname,
                UserCity = newRegularUserss.UserCity,
                UserVilingToChangeLocation = newRegularUserss.UserVilingToChangeLocation,
                UserFullTimeJob = newRegularUserss.UserFullTimeJob,
                UserWorkExperience = newRegularUserss.UserWorkExperience,
                UserKeyWords = newRegularUserss.UserKeyWords

            };
            RegularUserss.Add(finalRegularuser);


            return CreatedAtRoute(new
            { }, finalRegularuser);
        }

       [HttpPut("{Id}")]
        public IActionResult UpdateRegularUser(int id,
     [FromBody] RegularUserForUpdateDto newRegularUserss)
        {
            if (newRegularUserss == null)

            {
                return BadRequest();
            }

            var RegularUsersFromStore = RegularUserDataStore.Current.RegularUsers.FirstOrDefault(p =>p.UserId==id);

            if (RegularUsersFromStore == null)
            {
                return NotFound();
            }
            RegularUsersFromStore.UserName = newRegularUserss.UserName;
            RegularUsersFromStore.UserSurname = newRegularUserss.UserSurname;
            RegularUsersFromStore.UserCity = newRegularUserss.UserCity;
            RegularUsersFromStore.UserVilingToChangeLocation = newRegularUserss.UserVilingToChangeLocation;
            RegularUsersFromStore.UserFullTimeJob = newRegularUserss.UserFullTimeJob;
            RegularUsersFromStore.UserWorkExperience = newRegularUserss.UserWorkExperience;
            RegularUsersFromStore.UserKeyWords = newRegularUserss.UserKeyWords;



            return NoContent();

        }

       [HttpPatch("{Id}")]
        public IActionResult UpdateRegularUser(int id,
          [FromBody]JsonPatchDocument<RegularUserForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {

                BadRequest();
            }
            var RegularUsersFromStore = RegularUserDataStore.Current.RegularUsers.FirstOrDefault(p => p.UserId == id);

            if (RegularUsersFromStore == null)
            {
                return NotFound();
            }
            var regularUserToPatch = new RegularUserForUpdateDto()
            {
                UserName = RegularUsersFromStore.UserName,
                UserSurname = RegularUsersFromStore.UserSurname,
                UserCity = RegularUsersFromStore.UserCity,
                UserVilingToChangeLocation = RegularUsersFromStore.UserVilingToChangeLocation,
                UserFullTimeJob = RegularUsersFromStore.UserFullTimeJob,
                UserWorkExperience = RegularUsersFromStore.UserWorkExperience,
                UserKeyWords = RegularUsersFromStore.UserKeyWords

            };

            patchDoc.ApplyTo(regularUserToPatch);

            RegularUsersFromStore.UserName = regularUserToPatch.UserName;
            RegularUsersFromStore.UserSurname = regularUserToPatch.UserSurname;
            RegularUsersFromStore.UserCity = regularUserToPatch.UserCity;
            RegularUsersFromStore.UserVilingToChangeLocation = regularUserToPatch.UserVilingToChangeLocation;
            RegularUsersFromStore.UserFullTimeJob = regularUserToPatch.UserFullTimeJob;
            RegularUsersFromStore.UserWorkExperience = regularUserToPatch.UserWorkExperience;
            RegularUsersFromStore.UserKeyWords = regularUserToPatch.UserKeyWords;

            return NoContent();
        }

        [HttpDelete("{Id}")]

        public IActionResult deliteRegularUser(int id)
           
       
        {
            var RegularUserDelite = RegularUserDataStore.Current.RegularUsers.FirstOrDefault(c =>c.UserId == id);

            if (RegularUserDelite == null)
            {
                return NotFound();
            }

            RegularUserDataStore.Current.RegularUsers.Remove(RegularUserDelite);

            return NoContent();
        }


    }
}

