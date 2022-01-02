using Data.DB_Models;
using Repository.Interfaces;
using System;
using System.Linq;

namespace Logic.Helpers
{
    public class DBSeed
    {
        IWorkerRepo workerRepo;
        IDepartmentRepo departmentRepo;

        public DBSeed(IWorkerRepo workerRepo, IDepartmentRepo departmentRepo)
        {
            this.workerRepo = workerRepo;
            this.departmentRepo = departmentRepo;
        }

        public void PopulateDB()
        {
            AddDepartments();
            AddWorkers();
        }

        public void ClearDB()
        {
            throw new NotImplementedException();
        }

        private void AddWorkers()
        {
            var allDepartments = departmentRepo.GetAll().ToList();

            var worker = new Worker
            {
                Name = "Forgacs Akos",
                Active = true,
                PhoneNumber = "0690123456",
                UserName = "forgakos",
                Password = "string", //Not very safe but good for now
                Supervisor = "Bill Gates",
                Department = allDepartments[0]
            };
            workerRepo.Add(worker).Wait();

            worker = new Worker
            {
                Name = "Hortobágyi Mate",
                Active = true,
                PhoneNumber = "0690123456",
                UserName = "hortmate",
                Password = "string", //Not very safe but good for now
                Supervisor = "Bill Gates",
                Department = allDepartments[1]
            };
            workerRepo.Add(worker).Wait();

            worker = new Worker
            {
                Name = "Toth Viktoria",
                Active = true,
                PhoneNumber = "0690123456",
                UserName = "tothviki",
                Password = "string", //Not very safe but good for now
                Supervisor = "Bill Gates",
                Department = allDepartments[2]
            };
            workerRepo.Add(worker).Wait();

            worker = new Worker
            {
                Name = "Toth Dávid",
                Active = true,
                PhoneNumber = "0690123456",
                UserName = "tothdave",
                Password = "string", //Not very safe but good for now
                Supervisor = "Bill Gates",
                Department = allDepartments[3]
            };
            workerRepo.Add(worker).Wait();

            worker = new Worker
            {
                Name = "Nagy Peter",
                Active = true,
                PhoneNumber = "0690123456",
                UserName = "nagypete",
                Password = "string", //Not very safe but good for now
                Supervisor = "Bill Gates",
                Department = allDepartments[3]
            };
            workerRepo.Add(worker).Wait();
        }

        private void AddDepartments()
        {
            Department dprtmnt = new Department
            {
                Name = "Software Development",
                Abreviation = "SD",
                Active = true
            };
            departmentRepo.Add(dprtmnt).Wait();

            dprtmnt = new Department
            {
                Name = "Human Resources",
                Abreviation = "HR",
                Active = true
            };
            departmentRepo.Add(dprtmnt).Wait();

            dprtmnt = new Department
            {
                Name = "Networking and Security",
                Abreviation = "NS",
                Active = true
            };
            departmentRepo.Add(dprtmnt).Wait();

            dprtmnt = new Department
            {
                Name = "Database",
                Abreviation = "DB",
                Active = true
            };
            departmentRepo.Add(dprtmnt).Wait();
        }
    }
}
