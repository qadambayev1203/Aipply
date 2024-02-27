using AutoMapper;
using Entities.DTO.AppealsDTOS;
using Entities.DTO.StatusesDTOS;
using Entities.DTO.UserAuthorizatsionDTOS;
using Entities.Model.AppealsModel;
using Entities.Model.StatusesModel;
using Entities.Model.UsersModel;

namespace AippyWebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User DTO
            CreateMap<User, UserDTO>();




            //Appeal DTO
            CreateMap<AppealUpdatedDTO, Appeal>();
            CreateMap<AppealCreatedDTO, Appeal>();
            CreateMap<Appeal, AppealReadedDTO>();




            //StatusDTO
            CreateMap<Status, StatusReadedDTO>();
        }
    }
}
