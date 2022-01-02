﻿using Data.DB_Models;
using Logic.Helpers;
using Logic.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class DepartmentLogic : IDepartmentLogic
    {
        IDepartmentRepo departmentRepo;

        public DepartmentLogic(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        public async Task<Department> AddAsync(Department entity)
        {
            var query = (from x in departmentRepo.GetAll()
                         where x.Id == entity.Id
                         select x).FirstOrDefault();

            if (query == null)   //Check if it exists in the repo
            {
                try
                {
                    await departmentRepo.Add(entity);
                    entity.Active = true;
                    return entity;
                }
                catch
                {
                    entity.Active = false;
                    return entity;
                }
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.DepartmentExists);
            }
        }

        public async Task DeleteAsync(Department entity)
        {
            if (await departmentRepo.GetOne(entity.Id) != null)
            {
                await departmentRepo.Delete(entity.Id);
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.DepartmentNotFound);
            }
        }

        public async Task<Department> GetByIdAsync(long id)
        {
            return await departmentRepo.GetOne(id);
        }

        public async Task<IQueryable<Department>> Query(Expression<Func<Department, bool>> predicate)
        {
            return this.departmentRepo.GetAll().AsQueryable().Where(predicate);
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            var helper = await departmentRepo.GetOne(entity.Id);
            if (helper != null)
            {
                await departmentRepo.Update(entity.Id, entity);
                return entity;
            }
            else
            {
                throw new NotFoundException(WorkerErrorMessages.DepartmentNotFound);
            }
        }
    }
}