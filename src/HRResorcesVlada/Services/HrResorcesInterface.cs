using HRResorcesVlada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRResorcesVlada.Models;

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
        bool RegularUserExists(string regularUserName);
        bool RegularUserExistss(string regularUserSurname);
        void AddNewRegularUser(RegularUser newRegularUserss);
        bool RegularUserExistsPatch(string name);
        bool RegularUserExistsPatchh(string surname);
        IEnumerable<RegularUser> GetRegularUsers();
        
        RegularUser GetRegularUser(string name);
        RegularUser GetRegularUserSur(string surname);
        void DeliteRegularUser(RegularUser regularUserNameDelite);
        bool JobPositionExists(string newJobPositionss);
        void AddNewJobPosition(JobPosition newJobPositionss);
        bool JobPositionExists(int id);
        void DeliteJobPosition(JobPosition jobPositionDelite);
        IEnumerable<JobPosition> GetJobPositionsName(string name);
        IEnumerable<JobPosition> GetJobPositionsDescription(string description);
       
        IEnumerable<JobPosition> GetJobPositionsGrad(string city);
       
        IEnumerable<JobPosition> GetJobPositionsDrzava(string country);
        IEnumerable<JobPosition> GetJobPositionsParTime(string parttime);
        IEnumerable<JobPosition> GetJobPositionsKljRe(string keywords);
    }
}
