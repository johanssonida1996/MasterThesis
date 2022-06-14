using JobListing.Data;
using JobListing.Models;
using JobListing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly AppDbContext _db;
        private readonly FavoriteCart _favoriteCart;

        public CompanyController(AppDbContext db, IWorkerRepository workerRepository, ICategoryRepository categoryRepository, ICityRepository cityRepository, FavoriteCart favoriteCart)
        {
            _workerRepository = workerRepository;
            _categoryRepository = categoryRepository;
            _cityRepository = cityRepository;
            _db = db;
            _favoriteCart = favoriteCart;
        }

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult FavoriteCart()
        {
            var items = _favoriteCart.GetFavoriteCartItems();
            _favoriteCart.FavoriteCartItems = items;

            var favoriteCartViewModel = new FavoriteCartViewModel
            {
                FavoriteCart = _favoriteCart,
                //FavoriteCartTotal = _favoriteCart.()
            };

            return View(favoriteCartViewModel);

        }

        public RedirectToActionResult AddToFavoriteCart(int Id)
        {
            var selectedWorker = _workerRepository.AllWorkers.FirstOrDefault(w => w.Id == Id);

            if (selectedWorker != null)
            {
                _favoriteCart.AddToCart(selectedWorker);
            }
            return RedirectToAction("FavoriteCart");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedWorker = _workerRepository.AllWorkers.FirstOrDefault(w => w.Id == Id);

            if (selectedWorker != null)
            {
                _favoriteCart.RemoveFromCart(selectedWorker);
            }
            return RedirectToAction("FavoriteCart");
        }


        public IActionResult CompanySettings()
        {
            return View();
        }
    }
}
