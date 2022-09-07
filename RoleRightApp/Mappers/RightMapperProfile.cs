using AutoMapper;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Mappers;

public class RightMapperProfile : Profile
{
    public RightMapperProfile()
    {
        CreateMap<RightRequestModel, RightModel>();
    }
}