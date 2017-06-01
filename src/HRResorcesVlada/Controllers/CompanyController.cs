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
    [Route("api/company")]



    public class CompanyController : Controller
    {
        private HrResorcesInterface _hrResorcesInterface;

        public CompanyController(HrResorcesInterface hrResorcesInterface)
        {
            _hrResorcesInterface = hrResorcesInterface;
        }

        [HttpGet()]
        public IActionResult GetCompanies()

        {

            //  return Ok(CompanyDataStore.Current.Companies);
            var companyEntities = _hrResorcesInterface.GetCompanies();
            var results = Mapper.Map<IEnumerable<CompaniesWithoutJobPositionDto>>(companyEntities);
            // var results = new List<CompaniesWithoutJobPositionDto>();

            /*  foreach (var companyEntitie in companyEntities)
              {
                  results.Add(new CompaniesWithoutJobPositionDto
                  {
                      Name = companyEntitie.Name,
                      Description = companyEntitie.Description,
                      City = companyEntitie.City,
                      Country = companyEntitie.Country,
                      Phone = companyEntitie.Phone,
                      EmailAdress = companyEntitie.EmailAdress,
                      WebSite = companyEntitie.WebSite


                  });
              }*/

            return Ok(results);
        }







        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var companyToReturn = CompanyDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);

            if (companyToReturn == null)
            {
                return NotFound();

            }
            return Ok(companyToReturn);

        }

        [HttpPost()]
        public IActionResult CreateNewCompany([FromBody] CompaniesWithoutJobPositionDto newCompanys) //Oliver: Umesto CompaniesWithoutJobPositionDto 
                                                                                                     //	si stavio CompaniesWithoutJobPositionsDto

        {
            if (newCompanys == null)

            {
                return BadRequest();
            }

            string name = newCompanys.Name;

            /*  var Companys = CompanyDataStore.Current.Companies.FindAll(c => c.Name == name);

              if (Companys.Count != 0)
              {
                  return BadRequest("Ime postoji");
              }*/
           if (_hrResorcesInterface.CompanyExists(name))
            {
                return BadRequest("Postoji Kompanija  pod tim imenom");

            }

           var finalCompany = Mapper.Map<Entities.Company>(newCompanys);

            _hrResorcesInterface.AddNewCompany(finalCompany);

            if (!_hrResorcesInterface.Save())

            {
                return StatusCode(500, "nije sačuvano");
            }





            return CreatedAtRoute(new
            { }, finalCompany);
        }










        /* public IActionResult CreateNewCompany(int Id, [FromBody] CompanyForCreationDto newCompanys)

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
            { }, finalCompany);*/

        /*   [HttpPut("{Id}")]
                  public IActionResult UpdateCompany(int id,
               [FromBody] CompanyForUpdateDto newCompanys)
                  {
                      if (newCompanys == null)

                      {
                          return BadRequest();
                      }

                      var CompanyFromStore = CompanyDataStore.Current.Companies.FirstOrDefault(p =>p.Id==id);

                      if (CompanyFromStore == null)
                      {
                          return NotFound();
                      }
                      CompanyFromStore.Name = newCompanys.Name;
                      CompanyFromStore.Description =newCompanys.Description;
                      CompanyFromStore.City = newCompanys.City;
                      CompanyFromStore.Country = newCompanys.Country;
                      CompanyFromStore.Phone = newCompanys.Phone;
                      CompanyFromStore.EmailAdress = newCompanys.EmailAdress;
                      CompanyFromStore.WebSite = newCompanys.WebSite;



              return NoContent();

                  }*/

        [HttpPatch("{name}")]

        public IActionResult UpdateCompany(string name,
          [FromBody]JsonPatchDocument<CompanyForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {

                BadRequest();
            }

            if (!_hrResorcesInterface.CompanyExists(name))
            {
                return NotFound("Ne postoji Kompanija  pod tim imenom");

            }

            var companyEntity = _hrResorcesInterface.GetCompany(name);

            if (companyEntity == null)
            {
                return NotFound();

            }

            var companyToPatch = Mapper.Map<CompanyForUpdateDto>(companyEntity);

           /* patchDoc.ApplyTo(companyToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            TryValidateModel(companyToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(companyToPatch, companyEntity);



            if (!_hrResorcesInterface.Save())
            {

                return StatusCode(500, "nije sačuvano");
            }*/

            return NoContent();
        }

        /*     var CompanyFromStore = CompanyDataStore.Current.Companies.FirstOrDefault(p => p.Name == name);

              if (CompanyFromStore == null)
               {
                   return NotFound();
               }


             var companyToPatch = new CompanyForUpdateDto()
             {
                 Name = CompanyFromStore.Name,
                 Description = CompanyFromStore.Description,
                 City = CompanyFromStore.City,
                 Country = CompanyFromStore.Country,
                 Phone = CompanyFromStore.Phone,
                 EmailAdress = CompanyFromStore.EmailAdress,
                 WebSite = CompanyFromStore. WebSite

             };

             patchDoc.ApplyTo(companyToPatch);

             CompanyFromStore.Name = companyToPatch.Name;
             CompanyFromStore.Description = companyToPatch.Description;
             CompanyFromStore.City = companyToPatch.City;
             CompanyFromStore.Country= companyToPatch.Country;
             CompanyFromStore.Phone= companyToPatch.Phone;
             CompanyFromStore.EmailAdress = companyToPatch.EmailAdress;
             CompanyFromStore.WebSite = companyToPatch.WebSite;


             return NoContent();
         }*/
        [HttpDelete("{name}")]

        public IActionResult deliteCompany(string name)

        {

            if (!_hrResorcesInterface.CompanyExists(name))
            {
                return NotFound("Ne postoji Kompanija  pod tim imenom");

            }

            var companyDelite = _hrResorcesInterface.GetCompany(name);

            if (companyDelite == null)
            {

                return NotFound();
            }

           _hrResorcesInterface.DeliteCompany(companyDelite);

            if (!_hrResorcesInterface.Save())
            {

                return StatusCode(500, "nije sačuvano");
            }

            return NoContent();
         
            /*  {
                var CompanyDelite = CompanyDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);

                if (CompanyDelite == null)
                {
                    return NotFound();
                }

                CompanyDataStore.Current.Companies.Remove(CompanyDelite);

                return NoContent();
            }*/

        }
    }
}