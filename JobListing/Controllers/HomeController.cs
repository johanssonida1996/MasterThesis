using JobListing.Data;
using JobListing.Models;
using JobListing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkerRepository _workerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db, IWorkerRepository workerRepository, ICategoryRepository categoryRepository, ICityRepository cityRepository)
        {
            _logger = logger;
            _workerRepository = workerRepository;
            _categoryRepository = categoryRepository;
            _cityRepository = cityRepository;
            _db = db;
        }

      
        [HttpGet]
        public IActionResult Index(string category, string city, Worker worker, int worktype)
        {
            IEnumerable<Worker> workers;
            string currentCategory = null;
            string currentCity = null;
            string currentWorktype = null;
            //IList<WorkTypes> worktypes = null;



            if (!string.IsNullOrEmpty(category))
            {
                workers = _workerRepository.AllWorkers.Where(w => w.Category.CategoryName == category)
                 .OrderBy(w => w.Id);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            else if (!string.IsNullOrEmpty(city))
            {
                workers = _workerRepository.AllWorkers.Where(w => w.City.CityName == city)
                     .OrderBy(w => w.Id);
                currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityName == city)?.CityName;
            }
            else if (worktype != 0)
            {
                //var test = _db.WorkTypesWorker.Where(x => x.WorkTypesId.ToString() == worktype).OrderBy(x => x.WorkTypesId).ToList();
                workers = _workerRepository.AllWorkers.Where(w => w.WorkTypes.Any(x => x.WorkTypesId == worktype));
                //currentWorktype = _workerRepository.AllWorkers.FirstOrDefault(c => c.WorkTypes.Any(x => x.WorkTypesId.ToString() == worktype));
            }
            else
            {
                workers = _workerRepository.AllWorkers.OrderBy(w => w.Id);
                currentCity = "";
                currentCategory = "";
            }

           

            var workerViewModel = new WorkerListViewModel
            {

                Workers = workers,
                PopularWorkers = _workerRepository.PopularWorker,
                WorkTypeList = _db.WorkTypes.Select(o => new SelectListItem
                {
                    Text = o.WorkTypesName,
                    Value = o.Id.ToString(),
                }).ToList(),

                CategoryList = _db.Categories.Select(o => new SelectListItem
                {
                    Value = o.CategoryId.ToString(),
                    Text = o.CategoryName
                }).ToList(),

                CityList = _db.Cities.Select(o => new SelectListItem
                {
                    Value = o.CityId.ToString(),
                    Text = o.CityName
                }).ToList(),

                CurrentCategory = currentCategory,
                CurrentCity = currentCity,
                
            };

            return View(workerViewModel);
        }

        [HttpPost]
        public IActionResult Index(string searchString, string currentCity, string currentCategory)
        {
            IEnumerable<Worker> workers = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                workers = _workerRepository.AllWorkers.Where(s => s.JobTitle.Contains(searchString));

                if (!string.IsNullOrEmpty(currentCity) && currentCity != "Stad")
                {
                    if (!string.IsNullOrEmpty(currentCategory) && currentCategory != "Branch")
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.City.CityId.ToString() == currentCity && w.Category.CategoryId.ToString() == currentCategory && w.JobTitle.Contains(searchString))
                       .OrderBy(w => w.Id);
                        currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityId.ToString() == currentCity)?.CityId.ToString();
                        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId.ToString() == currentCategory)?.CategoryId.ToString();
                    }
                    else
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.City.CityId.ToString() == currentCity && w.JobTitle.Contains(searchString))
                        .OrderBy(w => w.Id);
                        currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityId.ToString() == currentCity)?.CityId.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(currentCategory) && currentCategory != "Branch")
                {
                    if (!string.IsNullOrEmpty(currentCity) && currentCity != "Stad")
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.City.CityId.ToString() == currentCity && w.Category.CategoryId.ToString() == currentCategory && w.JobTitle.Contains(searchString))
                       .OrderBy(w => w.Id);
                        currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityId.ToString() == currentCity)?.CityId.ToString();
                        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId.ToString() == currentCategory)?.CategoryId.ToString();
                    }
                    else
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.Category.CategoryId.ToString() == currentCategory && w.JobTitle.Contains(searchString))
                        .OrderBy(w => w.Id);
                        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId.ToString() == currentCategory)?.CategoryId.ToString();
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(currentCity) && currentCity != "Stad")
                {
                    if (!string.IsNullOrEmpty(currentCategory) && currentCategory != "Branch")
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.City.CityId.ToString() == currentCity && w.Category.CategoryId.ToString() == currentCategory)
                       .OrderBy(w => w.Id);
                        currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityId.ToString() == currentCity)?.CityId.ToString();
                        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId.ToString() == currentCategory)?.CategoryId.ToString();
                    }
                    else
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.City.CityId.ToString() == currentCity)
                        .OrderBy(w => w.Id);
                        currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityId.ToString() == currentCity)?.CityId.ToString();
                    }
                }
                if (!string.IsNullOrEmpty(currentCategory) && currentCategory != "Branch")
                {
                    if (!string.IsNullOrEmpty(currentCity) && currentCity != "Stad")
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.City.CityId.ToString() == currentCity && w.Category.CategoryId.ToString() == currentCategory)
                       .OrderBy(w => w.Id);
                        currentCity = _cityRepository.AllCities.FirstOrDefault(c => c.CityId.ToString() == currentCity)?.CityId.ToString();
                        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId.ToString() == currentCategory)?.CategoryId.ToString();
                    }
                    else
                    {
                        workers = _workerRepository.AllWorkers.Where(w => w.Category.CategoryId.ToString() == currentCategory)
                        .OrderBy(w => w.Id);
                        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId.ToString() == currentCategory)?.CategoryId.ToString();
                    }
                }
            }
       


            var workerViewModel = new WorkerListViewModel
            {

                Workers = workers,
                PopularWorkers = _workerRepository.PopularWorker,
                WorkTypeList = _db.WorkTypes.Select(o => new SelectListItem
                {
                    Text = o.WorkTypesName,
                    Value = o.Id.ToString()
                }).ToList(),

                CategoryList = _db.Categories.Select(o => new SelectListItem
                {
                    Value = o.CategoryId.ToString(),
                    Text = o.CategoryName
                }).ToList(),

                CityList = _db.Cities.Select(o => new SelectListItem
                {
                    Value = o.CityId.ToString(),
                    Text = o.CityName
                }).ToList(),
            };



            return View(workerViewModel);
        }

        public IActionResult InformationView(WorkerListViewModel model, int id)
        {
            model = new WorkerListViewModel
            {
                
                Workers = _workerRepository.AllWorkers,
                WorkTypeList = _db.WorkTypes.Select(o => new SelectListItem
                {
                    Text = o.WorkTypesName,
                    Value = o.Id.ToString()
                }).ToList(),

                CategoryList = _db.Categories.Select(o => new SelectListItem
                {
                    Value = o.CategoryId.ToString(),
                    Text = o.CategoryName
                }).ToList(),

                CityList = _db.Cities.Select(o => new SelectListItem
                {
                    Value = o.CityId.ToString(),
                    Text = o.CityName
                }).ToList(),

                Worker = _workerRepository.GetWorkerById2(id),
                PopularWorkers = _workerRepository.PopularWorker,
            
            };

            //ViewBag.ProfilImg = model.Worker.ImageUrl;

            if (model.Worker == null)
            {
                return NotFound();
            }

            return View(model);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
