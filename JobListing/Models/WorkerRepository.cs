using JobListing.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class WorkerRepository: IWorkerRepository
    {
        private readonly AppDbContext _appDbContext;
        public WorkerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Worker> AllWorkers
        {
            get
            {
                var test=  _appDbContext.Workers.Include(c => c.Category).Include(c => c.City).Include(w => w.WorkTypes).ThenInclude(y => y.worktype);
                return test;
            }
        }

        public IEnumerable<Worker> PopularWorker
        {
            get
            {
                return _appDbContext.Workers.Include(c => c.Category).Include(c => c.City).Where(p => p.PopularWorker);
            }
        }

        public Worker GetWorkerById(string Id)
        {
            var worker = _appDbContext.Workers.Include(c => c.City).Include(w => w.WorkTypes).ThenInclude(y => y.worktype).Include(e => e.Education).Include(c => c.Category).Include(f => f.Files).SingleOrDefault(p => p.CurrentUserId== Id);
            return worker;
        }

        public Worker GetWorkerById2(int Id)
        {
            var worker = _appDbContext.Workers.Include(c => c.City).Include(w => w.WorkTypes).ThenInclude(y => y.worktype).Include(e => e.Education).Include(c => c.Category).Include(f => f.Files).SingleOrDefault(p => p.Id == Id);
            return worker;
        }

        //public void Testar()
        //{
        //    GetWorkerById(0, 1, 2, 3)
        //}
    }
}
