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
                Id = ++ maxRegularUsersId,
                Name = newRegularUserss.Name,
                Surname = newRegularUserss.Surname,
                City = newRegularUserss.City,
                VilingToChangeLocation = newRegularUserss.VilingToChangeLocation,
                FullTimeJob = newRegularUserss.FullTimeJob,
                WorkExperience = newRegularUserss.WorkExperience,
                KeyWords = newRegularUserss.KeyWords

            };
            RegularUserss.Add(finalRegularuser);


            return CreatedAtRoute( new
            { }, finalRegularuser);
        }
    }
   }

