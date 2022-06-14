using JobListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext _appDbContext;
        public EducationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Education> AllEducations => _appDbContext.Educations;
    }
}
