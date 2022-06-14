using JobListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class WorkTypeRepository : IWorkTypeReository
    {
        private readonly AppDbContext _appDbContext;
        public WorkTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<WorkTypes> AllWorkTypes => _appDbContext.WorkTypes;
    }
}
