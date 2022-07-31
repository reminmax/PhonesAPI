using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesAPI.Entities;
using PhonesAPI.Helpers;

namespace PhonesAPI.Services
{
    public interface IMakerPhoneRepository
    {
        IEnumerable<Phone> GetPhones(Guid makerId);
        PagedList<Phone> GetPhones(Guid makerId, PhonesResourceParameters phonesResourceParameters);
        Phone GetPhone(Guid makerId, Guid phoneId);
        void AddPhone(Guid makerId, Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(Phone phone);

        IEnumerable<Maker> GetMakers();
        PagedList<Maker> GetMakers(MakersResourceParameters makersResourceParameters);
        Maker GetMaker(Guid makerId);
        IEnumerable<Maker> GetMakers(IEnumerable<Guid> makerIds);
        void AddMaker(Maker maker);
        void UpdateMaker(Maker maker);
        void DeleteMaker(Maker maker);

        bool MakerExists(Guid makerId);
        bool PhoneExists(Guid phoneId);
        bool Save();
    }
}
