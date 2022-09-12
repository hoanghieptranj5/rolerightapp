using AutoMapper;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Mappers
{
    public class RequestMapperProfile : Profile
    {
        public RequestMapperProfile()
        {
            CreateMap<RequestRequestModel, RequestModel>();
        }
    }
}
