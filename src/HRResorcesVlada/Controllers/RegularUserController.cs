using HRResorcesVlada.Models;
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


        [HttpGet()]
        public IActionResult GetRegularUsers()

        {

            return Ok(RegularUserDataStore.Current.RegularUsers);

        }

        [HttpGet("{id}")]
        public IActionResult GetRegularUser(int id)
        {
            var regularUserToReturn = RegularUserDataStore.Current.RegularUsers.FirstOrDefault(c => c.Id == id);

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

            var maxRegularUsersId = RegularUserDataStore.Current.RegularUsers.Max(c => c.Id);

            var finalRegularuser = new RegularUserDto()
            {
                Id = ++maxRegularUsersId,
                Name = newRegularUserss.Name,
                Surname = newRegularUserss.Surname,
                City = newRegularUserss.City,
                VilingToChangeLocation = newRegularUserss.VilingToChangeLocation,
                FullTimeJob = newRegularUserss.FullTimeJob,
                WorkExperience = newRegularUserss.WorkExperience,
                KeyWords = newRegularUserss.KeyWords

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

            var RegularUsersFromStore = RegularUserDataStore.Current.RegularUsers.FirstOrDefault(p =>p.Id==id);

            if (RegularUsersFromStore == null)
            {
                return NotFound();
            }
            RegularUsersFromStore.Name = newRegularUserss.Name;
            RegularUsersFromStore.Surname = newRegularUserss.Surname;
            RegularUsersFromStore.City = newRegularUserss.City;
            RegularUsersFromStore.VilingToChangeLocation = newRegularUserss.VilingToChangeLocation;
            RegularUsersFromStore.FullTimeJob = newRegularUserss.FullTimeJob;
            RegularUsersFromStore.WorkExperience = newRegularUserss.WorkExperience;
            RegularUsersFromStore.KeyWords = newRegularUserss.KeyWords;



            return NoContent();

        }
       
    }
}

