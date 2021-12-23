using AutoMapper;
using Data.DB_Models;
using Logic.DTO_Models;

namespace Logic.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateWorkerDTO, Worker>();
            CreateMap<Worker, ListWorkersDTO>();
        }
    }
}
