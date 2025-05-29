using AutoMapper;
using Yummy.Api.Dtos.NotificationDtos;
using Yummy.Api.Entitites;

namespace Yummy.Api.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
            CreateMap<GetNotificationByIdDto, Notification>().ReverseMap();
            CreateMap<ResultNotificationDto, Notification>().ReverseMap();
        }
    }
}
