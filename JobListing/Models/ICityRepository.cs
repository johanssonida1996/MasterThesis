using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> AllCities { get; }
    }
}
