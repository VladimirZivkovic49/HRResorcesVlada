﻿using System;
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
            return _context.Jobpositions.Where(p => p.Id == Id).FirstOrDefault();
        }

        public IEnumerable<JobPosition> GetJobPositions()
        {
            return _context.Jobpositions.ToList();
        }
    }
}