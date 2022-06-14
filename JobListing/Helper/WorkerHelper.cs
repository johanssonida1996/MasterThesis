using JobListing.Data;
using JobListing.Enum;
using JobListing.Models;
using JobListing.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Helper
{
    public class WorkerHelper
    {
        private readonly AppDbContext db;
        private readonly IWorkerRepository workerRepository;
        private readonly string currentUserId;

        public WorkerHelper(AppDbContext _db, IWorkerRepository _workerRepository, string _currentUserId)
        {
            db = _db;
            workerRepository = _workerRepository;
            currentUserId = _currentUserId;

        }

        public UserInformationViewModel GetUserInformationViewModel(Worker worker)
        {

            var workTypes = worker.WorkTypes.Select(x => x.WorkTypesId);
            var viewmodel = new UserInformationViewModel
            {
                EducationList = db.Educations.Select(o => new Education
                {
                    EducationId = o.EducationId,
                    EducationName = o.EducationName,
                    IsSelected = o.IsSelected
                }).ToList(),

                WorkTypeList = db.WorkTypes.Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.WorkTypesName,
                    Selected = workTypes.Any(t => t == o.Id)
                }).ToList(),

                CategoryList = db.Categories.Select(o => new SelectListItem
                {
                    Value = o.CategoryId.ToString(),
                    Text = o.CategoryName
                }).ToList(),

                CityList = db.Cities.Select(o => new SelectListItem
                {
                    Value = o.CityId.ToString(),
                    Text = o.CityName
                }).ToList(),

                CurrentUserId = currentUserId,
                WorkerId = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Email = worker.Email,
                City = worker.City,
                CityTest = worker.City.CityId.ToString(),

                JobTitle = worker.JobTitle,
                Branch = worker.Category.CategoryId.ToString(),
                ShortDescription = worker.ShortDescription,
                LongDescription = worker.LongDescription,

                Education = worker.Education,
                WorkExperience = System.Enum.Parse<WorkExperienceEnum>(worker.WorkExperience),
                Img = worker.ImageUrl,

            };

            if (worker.Files.Any())
            {
                viewmodel.files = worker.Files;
            }

            return viewmodel;
        }

        public UserInformationViewModel GetEmptyUser()
        {
            var viewmodel = new UserInformationViewModel
            {
                EducationList = db.Educations.Select(o => new Education
                {
                    EducationId = o.EducationId,
                    EducationName = o.EducationName,
                    IsSelected = o.IsSelected
                }).ToList(),

                WorkTypeList = db.WorkTypes.Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.WorkTypesName

                }).ToList(),

                CategoryList = db.Categories.Select(o => new SelectListItem
                {
                    Value = o.CategoryId.ToString(),
                    Text = o.CategoryName
                }).ToList(),

                CityList = db.Cities.Select(o => new SelectListItem
                {
                    Value = o.CityId.ToString(),
                    Text = o.CityName
                }).ToList(),

            };
            return viewmodel;
        }
    }
}
