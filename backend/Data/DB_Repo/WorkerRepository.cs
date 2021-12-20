using Data.DB_Models;
using Data.DB_Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class WorkerRepository : IRepository<Worker>
    {
        public DbSet<Worker> DbSet { get; set; }
    }
}
