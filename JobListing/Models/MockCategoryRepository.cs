using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class MockCategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
         new List<Category>
        {
                new Category{CategoryId=1, CategoryName="IT"},
                new Category{CategoryId=2, CategoryName="Bygg"},
                new Category{CategoryId=3, CategoryName="Utvecklare"},
                new Category{CategoryId=4, CategoryName="Kassabiträde"},
                new Category{CategoryId=5, CategoryName="Kundtjänst"},
                new Category{CategoryId=6, CategoryName="Vård och Omsorg"},
                new Category{CategoryId=7, CategoryName="Annat"}
         };
    }
}
