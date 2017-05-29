using HRResorcesVlada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Services
{
   public  interface HrResorcesInterface
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompany(string Name);
        IEnumerable<JobPosition> GetJobPositions();
        JobPosition GetJobPositio(int Id);
        void AddNewCompany(Company newCompanys);
        void DeliteCompany(Company newCompanys);

        bool Save();
        bool CompanyExists(string name);
    }
}
