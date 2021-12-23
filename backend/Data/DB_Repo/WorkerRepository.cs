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
    public class WorkerRepository : IRepository<Worker>
    {
        public virtual DbSet<Worker> DbSet { get; set; }
    }
}
