using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRResorcesVlada.Entities;

namespace HRResorcesVlada.Services
{
   


    public class HrResorcesRepository : HrResorcesInterface
    {
        private HrResorcesContext _context;
        public HrResorcesRepository(HrResorcesContext context)
        {
            _context = context;
        }

        
        public void AddNewCompany( Company newCompanys)
        {
            _context.Companies.Add(newCompanys);
        }

        public void AddNewRegularUser(RegularUser newRegularUserss)
        {
            _context.RegularUsers.Add(newRegularUserss);
        }

        public bool CompanyExists(string name)
        {
            return _context.Companies.Any(c => c.Name == name);
        }

        public void DeliteCompany(Company newCompanys)
        {
           // _context.Companies.Remove(newCompanys);
        }

        public void DeliteRegularUser(RegularUser regularUserNameDelite)
        {
             _context.RegularUsers.Remove(regularUserNameDelite);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies.OrderBy(c => c.Name).ToList();
        }

        public Company GetCompany(string Name)
        {
            return _context.Companies.Where(c => c.Name == Name).FirstOrDefault();
        }

        public JobPosition GetJobPositio(int Id)
        {
            return _context.Jobpositions.Where(p => p.JobId == Id).FirstOrDefault();
        }

        public IEnumerable<JobPosition> GetJobPositions()
        {
            return _context.Jobpositions.ToList();
        }

        public RegularUser GetRegularUser(string name)
        {
            return _context.RegularUsers.Where(c => c.UserName == name ).FirstOrDefault();
        }

        public IEnumerable<RegularUser> GetRegularUsers()
        {
             return _context.RegularUsers.OrderBy(c => c.UserName).ToList();
        }

        public RegularUser GetRegularUserSur(string surname)
        {
             return _context.RegularUsers.Where(c => c.UserSurname == surname ).FirstOrDefault();
        }

        public bool RegularUserExists(string regularUserName)
        {
            return _context.RegularUsers.Any(c => c.UserName == regularUserName);
        }

        public bool RegularUserExistsPatch(string name)
        {
            return _context.RegularUsers.Any(c => c.UserName == name);
        }

        public bool RegularUserExistsPatchh(string surname)
        {
            return _context.RegularUsers.Any(c => c.UserName ==surname);
        }

        public bool RegularUserExistss(string regularUserSurname)
        {
            return _context.RegularUsers.Any(c => c.UserSurname == regularUserSurname);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0); 
        }
    }
}
