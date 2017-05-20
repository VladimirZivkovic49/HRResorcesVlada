using HRResorcesVlada.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Controllers
{
    public class DummyController: Controller
    {
        private HrResorcesContext _hrx;

        public DummyController (HrResorcesContext hrx)
        {
            _hrx = hrx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }

    }
}
