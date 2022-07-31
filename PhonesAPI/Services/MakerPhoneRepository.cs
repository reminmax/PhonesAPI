using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesAPI.DbContexts;
using PhonesAPI.Entities;
using PhonesAPI.Helpers;

namespace PhonesAPI.Services
{
    public class MakerPhoneRepository: IMakerPhoneRepository
    {
        private readonly MakerPhoneContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public MakerPhoneRepository(MakerPhoneContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService;
        }


        public IEnumerable<Phone> GetPhones(Guid makerId)
        {
            if (makerId == Guid.Empty)
                throw new ArgumentNullException(nameof(makerId));

            return _context.Phones.Where(p => p.MakerId == makerId)
                .OrderBy(p => p.ModelName).ToList();
        }

        public PagedList<Phone> GetPhones(Guid makerId, PhonesResourceParameters phonesResourceParameters)
        {
            if (phonesResourceParameters is null)
                throw new ArgumentNullException(nameof(phonesResourceParameters));

            //if (string.IsNullOrWhiteSpace(phonesResourceParameters.OS) && string.IsNullOrWhiteSpace(phonesResourceParameters.SearchQuery))
            //    return GetPhones(makerId);

            var collection = _context.Phones as IQueryable<Phone>;
            collection = collection.Where(p => p.MakerId == makerId);

            if (!string.IsNullOrWhiteSpace(phonesResourceParameters.OS))
            {
                var os = phonesResourceParameters.OS.Trim();
                collection = collection.Where(p => p.OS == os && p.MakerId == makerId);
            }

            if (!string.IsNullOrWhiteSpace(phonesResourceParameters.SearchQuery))
            {
                var searchQuery = phonesResourceParameters.SearchQuery.Trim();
                collection = collection.Where(p => p.ModelName.Contains(searchQuery) && p.MakerId == makerId);
            }

            return PagedList<Phone>.Create(collection,
                phonesResourceParameters.PageNumber,
                phonesResourceParameters.PageSize);

            //return collection
            //    .Skip(phonesResourceParameters.PageSize * (phonesResourceParameters.PageNumber - 1))
            //    .Take(phonesResourceParameters.PageSize)
            //    .ToList();
        }

        public Phone GetPhone(Guid makerId, Guid phoneId)
        {
            if (makerId == Guid.Empty)
                throw new ArgumentNullException(nameof(makerId));

            if (phoneId == Guid.Empty)
                throw new ArgumentNullException(nameof(phoneId));

            return _context.Phones.Where(p => p.Id == phoneId && p.MakerId == makerId).FirstOrDefault();
        }

        public void AddPhone(Guid makerId, Phone phone)
        {
            if (makerId == Guid.Empty)
                throw new ArgumentNullException(nameof(makerId));

            if (phone is null)
                throw new ArgumentNullException(nameof(phone));

            phone.MakerId = makerId;
            _context.Phones.AddAsync(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            // not implemented
        }

        public void DeletePhone(Phone phone)
        {
            if (phone is null)
                throw new ArgumentNullException(nameof(phone));

            _context.Phones.Remove(phone);
        }

        public IEnumerable<Maker> GetMakers() => _context.Makers.ToList();

        public PagedList<Maker> GetMakers(MakersResourceParameters makersResourceParameters)
        {
            if (makersResourceParameters is null)
                throw new ArgumentNullException(nameof(makersResourceParameters));

            var collection = _context.Makers as IQueryable<Maker>;

            if (!string.IsNullOrWhiteSpace(makersResourceParameters.SearchQuery))
            {
                var searchQuery = makersResourceParameters.SearchQuery.Trim();
                collection = collection.Where(p => p.Name.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(makersResourceParameters.OrderBy))
            {
                var makerPropertyMappingDictionary =
                    _propertyMappingService.GetPropertyMapping<Models.MakerDto, Entities.Maker>();

                collection = collection.ApplySort(makersResourceParameters.OrderBy, makerPropertyMappingDictionary);
            }

            return PagedList<Maker>.Create(collection, 
                makersResourceParameters.PageNumber,
                makersResourceParameters.PageSize);
        }


        public Maker GetMaker(Guid makerId)
        {
            if (makerId == Guid.Empty)
                throw new ArgumentNullException(nameof(makerId));

            return _context.Makers.FirstOrDefault(m => m.Id == makerId);
        }

        public IEnumerable<Maker> GetMakers(IEnumerable<Guid> makerIds)
        {
            if (makerIds is null)
                throw new ArgumentNullException(nameof(makerIds));

            return _context.Makers.Where(m => makerIds.Contains(m.Id))
                .OrderBy(m => m.Name).ToList();
        }

        public void AddMaker(Maker maker)
        {
            if (maker is null)
                throw new ArgumentNullException(nameof(maker));

            _context.Makers.Add(maker);
        }

        public void UpdateMaker(Maker maker)
        {
            // not implemented
        }

        public void DeleteMaker(Maker maker)
        {
            if (maker is null)
                throw new ArgumentNullException(nameof(maker));

            _context.Makers.Remove(maker);
        }

        public bool MakerExists(Guid makerId)
        {
            if (makerId == Guid.Empty)
                throw new ArgumentNullException(nameof(makerId));

            return _context.Makers.Any(m => m.Id == makerId);
        }

        public bool PhoneExists(Guid phoneId)
        {
            if (phoneId == Guid.Empty)
                throw new ArgumentNullException(nameof(phoneId));

            return _context.Phones.Any(p => p.Id == phoneId);
        }

        public bool Save() => (_context.SaveChanges() >= 0);
    }
}
