using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PhonesAPI.Profiles
{
    public class MakersProfile: Profile
    {
        public MakersProfile()
        {
            CreateMap<Entities.Maker, Models.MakerDto>();

            CreateMap<Models.MakerForCreatingDto, Entities.Maker>();
        }
    }
}
