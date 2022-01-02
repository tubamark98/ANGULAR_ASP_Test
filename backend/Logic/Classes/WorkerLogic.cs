﻿using Data.DB_Models;
using Logic.Helpers;
using Logic.Interfaces;
using Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class WorkerLogic : IWorkerLogic
    {
        IWorkerRepo workerRepo;

        public WorkerLogic(IWorkerRepo workerRepo)
        {
            this.workerRepo = workerRepo;
        }

        public async Task<Worker> AddAsync(Worker worker)
        {
            try
            {
                await workerRepo.Add(worker);
                worker.Active = true;
                return worker;
            }
            catch
            {
                worker.Active = false;
                return worker;
            }
        }

        public async Task DeleteAsync(Worker worker)
        {
            if (await workerRepo.GetOne(worker.Id) != null)
            {
                await workerRepo.Delete(worker.Id);
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerNotFound);
            }
        }

        public async Task<Worker> GetByIdAsync(long id)
        {
            return await workerRepo.GetOne(id);
        }

        public async Task<IQueryable<Worker>> Query(Expression<Func<Worker, bool>> predicate)
        {
            return this.workerRepo.GetAll().AsQueryable().Where(predicate); //not async yet
        }

        public async Task<Worker> UpdateAsync(Worker worker)
        {
            var helper = await workerRepo.GetOne(worker.Id);
            if (helper != null)
            {
                await workerRepo.Update(worker.Id, worker);
                return worker;
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.WorkerNotFound);
            }
        }
    }
}
