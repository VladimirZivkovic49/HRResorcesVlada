using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRResorcesVlada.Entities
{
    public class HrResorcesContext: DbContext

    {
public  HrResorcesContext(DbContextOptions<HrResorcesContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosition>Jobpositions { get; set; }


    }
}
