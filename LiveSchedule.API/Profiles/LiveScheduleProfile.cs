using AutoMapper;
using LiveSchedule.API.DTOs;
using Models = LiveSchedule.API.Domains.Models;

namespace LiveSchedule.API.Profiles
{
    public class LiveScheduleProfile : Profile
    {
        public LiveScheduleProfile()
        {
            CreateMap<Models.LiveSchedule, LiveScheduleDto>().ReverseMap();
        }
    }
}
