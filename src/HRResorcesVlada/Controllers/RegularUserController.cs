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
            if(regularUserToReturn == null)
            {
                return NotFound();
            }

            return Ok(regularUserToReturn);
                
            }

        }
   }

