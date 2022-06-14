using JobListing.Data;
using JobListing.Enum;
using JobListing.Models;
using JobListing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JobListing.Providers;
using JobListing.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using JobListing.Helper;

namespace JobListing.Controllers
{
    //[Area("worker")]
    //[Route("[area]/id")]
    [Authorize(Roles = "Admin, Arbetssökande")]
    public class WorkerController : Controller
    {

        private readonly AppDbContext db;
        private readonly IIdentityProvider identityProvider;
        private IHostingEnvironment environment;
        private readonly IWorkerRepository workerRepository;

        public WorkerController(AppDbContext _db, IHostingEnvironment _environment, IIdentityProvider _identityProvider, IWorkerRepository _workerRepository)
        {
            db = _db;
            environment = _environment;
            identityProvider = _identityProvider;
            workerRepository = _workerRepository;

        }

        public IActionResult Index()
        {
            var currentuserId = identityProvider.Current.GetId();
            var worker = workerRepository.GetWorkerById(currentuserId);

            if (worker == null)
            {
                return View();
            }
            else
            {
                var helper = new WorkerHelper(db, workerRepository, currentuserId);
                var viewmodel = helper.GetUserInformationViewModel(worker);
                ViewBag.ProfilImg = worker.ImageUrl;
                return View(viewmodel);

            }
        }

        [HttpGet]
        public IActionResult WorkerInformation()
        {
            var currentuserId = identityProvider.Current.GetId();
            var worker = workerRepository.GetWorkerById(currentuserId);
            var helper = new WorkerHelper(db, workerRepository, currentuserId);

            if (worker == null)
            {

                var viewmodel = helper.GetEmptyUser();
 
                return View(viewmodel);
            }
            else
            {

                var viewmodel = helper.GetUserInformationViewModel(worker);
                ViewBag.ProfilImg = worker.ImageUrl;
                return View(viewmodel);
            }
        }

        private string GetImageString(IFormFile upload)
        {
            var base64string = string.Empty;

            if (upload.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    upload.CopyTo(stream);
                    var imageBytes = stream.ToArray();
                    base64string = $"data:{upload.ContentType};base64, {Convert.ToBase64String(imageBytes)}";
                }
            }
            return base64string;
        }

        private Files UploadedFile(IFormFile upload)
        {
            Files file = new Files();

            if (upload.Length > 0)
            {
                string uploadsFolder = Path.Combine(environment.WebRootPath, "assets");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + upload.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new MemoryStream())
                {
                    upload.CopyTo(stream);
                    file.Data = stream.ToArray();
                    file.FileName = uniqueFileName;
                }
            }
            return file;
        }


        [HttpPost]
        public async Task<IActionResult> WorkerInformation(UserInformationViewModel model)
        {
            var currentUserId = identityProvider.Current.GetId();
            var worker = workerRepository.GetWorkerById(currentUserId);
            model.City = workerRepository.GetWorkerById(currentUserId).City;
            var createUser = false;

            var workTypes = model.WorkTypeList.Where(x => x.Selected).Select(y => new WorkTypesWorker() {
                WorkerId = worker == null ? 0 : worker.Id,
                WorkTypesId = int.Parse(y.Value),
            }).ToList();

            if (ModelState.IsValid)
            {

                if (worker == null)
                {
                    createUser = true;
                    worker = new Worker
                    {
                        CurrentUserId = currentUserId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        CityId = model.City.CityId,

                        JobTitle = model.JobTitle,
                        CategoryId = int.Parse(model.Branch),
                        ShortDescription = model.ShortDescription,
                        LongDescription = model.LongDescription,

                        EducationId = model.EducationList.SingleOrDefault(x => x.IsSelected).EducationId,
                        WorkExperience = model.WorkExperience.ToString(),
                        WorkTypes = workTypes,
                        Files = new List<Files>()
                    };
                }
                else
                {

                    worker.FirstName = model.FirstName;
                    worker.LastName = model.LastName;
                    worker.Email = model.Email;
                    worker.CityId = model.City.CityId;
                    worker.JobTitle = model.JobTitle;
                    worker.CategoryId = int.Parse(model.Branch);
                    worker.ShortDescription = model.ShortDescription;
                    worker.LongDescription = model.LongDescription;
                    worker.EducationId = model.EducationList.SingleOrDefault(x => x.IsSelected).EducationId;
                    worker.WorkExperience = model.WorkExperience.ToString();
                    worker.WorkTypes = workTypes;

                }



                //var selectWorkType = model.WorkTypeList.Where(x => x.Selected).Select(y => y.Value).ToList();
                //if(selectWorkType != null)
                //{
                //    //model.WorkTypes = selectWorkType;
                //    foreach (var worktype in selectWorkType)
                //    {
                //        worker.WorkTypes.Add(new WorkTypesWorker
                //        {
                //            WorkTypesId = int.Parse(worktype)
                //        });
                //    }
                //}
                

                string imagesFileName = null;

                if (model.ImageFile != null)
                {
                    imagesFileName = (GetImageString(model.ImageFile));
                    worker.ImageUrl = imagesFileName;
                }

                if (model.FileOne != null)
                {
                    worker.Files.Add(UploadedFile(model.FileOne));
                }
                if (model.FileTwo != null)
                {
                    worker.Files.Add(UploadedFile(model.FileTwo));
                }
                if (model.FileThree != null)
                {
                    worker.Files.Add(UploadedFile(model.FileThree));
                }

                if (createUser)
                    await db.Workers.AddAsync(worker);

                await db.SaveChangesAsync();


                return RedirectToAction("Index", "Worker");

            }


            if (!ModelState.IsValid)
            {
                var city = db.Cities.Select(o => new SelectListItem
                {
                    Value = o.CityId.ToString(),
                    Text = o.CityName
                }).ToList();
                var branch = db.Categories.Select(o => new SelectListItem
                {
                    Value = o.CategoryId.ToString(),
                    Text = o.CategoryName
                }).ToList();

                var education = db.Educations.Select(o => new Education
                {
                    EducationId = o.EducationId,
                    EducationName = o.EducationName,
                    IsSelected = o.IsSelected
                }).ToList();

                var workType = db.WorkTypes.Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.WorkTypesName,
                    //IsSelected = o.IsSelected
                }).ToList();

                model.CityList = city;
                model.CategoryList = branch;
                model.EducationList = education;
                model.WorkTypeList = workType;

                //return View(model);
            }
            return View(model);
        }


        // GET: ForumFiles/Download/5
        public async Task<IActionResult> DownloadFile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var forumFile = await db.Files
            .FirstOrDefaultAsync(m => m.Id == id);
            if (forumFile == null)
            {
                return NotFound();
            }
            return File(forumFile.Data, MediaTypeNames.Application.Octet, forumFile.FileName);
        }


        // GET: ApplicationFiles/Delete/5
        public async Task<IActionResult> DeleteFile(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var forumFile = await db.Files
            .FirstOrDefaultAsync(m => m.Id == id);
            if (forumFile == null)
            {
                return NotFound();
            }
            else 
            {
                var forumFile2 = await db.Files.FindAsync(id);
                db.Files.Remove(forumFile2);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult WorkerNotis()
        {
            return View();
        }

        public IActionResult WorkerSettings()
        {
            return View();
        }
    }
}
