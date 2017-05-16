using HRResorcesVlada.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Controllers
{
    [Route("api/company")]

    public class CompanyController : Controller
    {


       [HttpGet()]
        public IActionResult GetCompanies()

        {

            return Ok(CompanyDataStore.Current.Companies);

        }
       /*   [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var companyToReturn = CompanyDataStore.Current.Companies.FirstOrDefault(c => c.Id==id);
           
            if (companyToReturn == null)
            {
                return NotFound();

            }
            return Ok(companyToReturn);
                
        }*/
        [HttpPost()]
        public IActionResult CreateNewCompany(int Id, [FromBody] CompanyForCreationDto newCompanys)

        {
            if (newCompanys == null)

            {
                return BadRequest();
            }
            var Companys = CompanyDataStore.Current.Companies;

            if (Companys == null)
            {
                return NotFound();
            }
            
            var maxCompaniesId = CompanyDataStore.Current.Companies.Max(c => c.Id);
            
            var finalCompany = new CompanyDto()
            {
                Id = ++ maxCompaniesId,
                Name = newCompanys.Name,
               Description = newCompanys.Description,
                City = newCompanys.City,
               Country = newCompanys.Country,
                Phone = newCompanys.Phone,
               EmailAdress = newCompanys.EmailAdress,
                WebSite = newCompanys.WebSite

            };
            Companys.Add(finalCompany);


            return CreatedAtRoute( new
            { }, finalCompany);
        }

    }
}
