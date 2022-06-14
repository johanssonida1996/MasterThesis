using JobListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _appDbContext;
        public CityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<City> AllCities => _appDbContext.Cities;
    }
}
