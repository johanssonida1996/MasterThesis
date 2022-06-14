using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class MockCityRepository
    {

        public IEnumerable<City> AllCities =>
         new List<City>
        {
                    new City{CityId=1, CityName="Stockholm"},
                    new City{CityId=2, CityName="Göteborg"},
                    new City{CityId=3, CityName="Malmö"},
                    new City{CityId=4, CityName="Örebro"},
                    new City{CityId=5, CityName="Västerrås"}

         };
    }
}
