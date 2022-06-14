using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> AllWorkers { get; }
        IEnumerable<Worker> PopularWorker { get; }
        Worker GetWorkerById(string Id);
        Worker GetWorkerById2(int Id);
    }
}
