using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhonesAPI.Helpers;
using PhonesAPI.Models;

namespace PhonesAPI.Profiles
{
    public class PhonesProfile: Profile
    {
        public PhonesProfile()
        {
            CreateMap<Entities.Phone, Models.PhoneDto>()
                .ForMember(
                    dest => dest.ReleasedMonthsAgo,
                    opt => opt.MapFrom(src => $"{src.ReleaseDate.ToString("dd/MM/yyyy")} ({src.ReleaseDate.GetMonthsAgo()} months ago)")
                    );

            CreateMap<PhoneForCreatingDto, Entities.Phone>();

            CreateMap<Models.PhoneForUpdatingDto, Entities.Phone>().ReverseMap();
        }
    }
}
