using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PhonesAPI.Helpers;
using PhonesAPI.Models;
using PhonesAPI.Services;

namespace PhonesAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/makers/{makerId}/phones")]
    [ResponseCache(CacheProfileName = "MainCacheProfile")]
    [ApiVersion("1.0")]
    public class PhonesController : ControllerBase
    {
        private readonly IMakerPhoneRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPropertyValidationService _propertyValidationService;

        public PhonesController(IMakerPhoneRepository repository, 
            IMapper mapper,
            IPropertyValidationService propertyValidationService)
        {
            _repository = repository ?? 
                          throw new ArgumentNullException(nameof(repository));
            
            _mapper = mapper ?? 
                      throw new ArgumentNullException(nameof(mapper));

            _propertyValidationService = propertyValidationService ??
                                         throw new ArgumentNullException(nameof(propertyValidationService));

        }

        [HttpGet(Name = "GetPhonesForMaker")]
        public IActionResult GetPhonesForMaker(Guid makerId, [FromQuery] PhonesResourceParameters phonesResourceParameters)
        {
            if (!_repository.MakerExists(makerId))
                return NotFound();

            if (!_propertyValidationService.HasValidProperties<MakerDto>
                    (phonesResourceParameters.Fields))
                return BadRequest();

            var phones = _repository.GetPhones(makerId, phonesResourceParameters);

            var previuosPageLink =
                phones.HasPrevious ? CreatePhonesUri(phonesResourceParameters, UriType.PreviousPage) : null;

            var nextPageLink =
                phones.HasNext ? CreatePhonesUri(phonesResourceParameters, UriType.NextPage) : null;

            var metaData = new
            {
                totalCount = phones.TotalCount,
                pageSize = phones.PageSize,
                currentPage = phones.CurrentPage,
                totalPages = phones.TotalPages,
                previuosPageLink = previuosPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metaData));

            return Ok(_mapper.Map<IEnumerable<PhoneDto>>(phones)
                .ShapeData(phonesResourceParameters.Fields));
        }

        [HttpGet("{phoneId}", Name = "GetPhoneForMaker")]
        public ActionResult<PhoneDto> GetPhoneForMaker(Guid makerId, Guid phoneId, string fields)
        {
            if (!_repository.MakerExists(makerId))
                return NotFound();

            if (!_propertyValidationService.HasValidProperties<MakerDto>(fields))
                return BadRequest();

            var phone = _repository.GetPhone(makerId, phoneId);
            if (phone is null)
                return NotFound();

            return Ok(_mapper.Map<PhoneDto>(phone).ShapeData(fields));
        }

        [HttpPost]
        public ActionResult<PhoneDto> CreatePhoneForMaker(Guid makerId, [FromBody] PhoneForCreatingDto phone)
        {
            if (!_repository.MakerExists(makerId))
                return NotFound();

            var phoneEntity = _mapper.Map<Entities.Phone>(phone);
            _repository.AddPhone(makerId, phoneEntity);
            _repository.Save();

            var phoneToReturn = _mapper.Map<PhoneDto>(phoneEntity);

            return CreatedAtRoute("GetPhoneForMaker", new { makerId = makerId, phoneId = phoneToReturn.Id },
                phoneToReturn);
        }

        [HttpPut("{phoneId}")]
        public ActionResult UpdatePhoneForMaker(Guid makerId, Guid phoneId, [FromBody] PhoneForUpdatingDto phone)
        {
            if (!_repository.MakerExists(makerId))
                return NotFound();

            var phoneFromRepo = _repository.GetPhone(makerId, phoneId);
            if (phoneFromRepo is null)
            {
                var phoneToAdd = _mapper.Map<Entities.Phone>(phone);
                phoneToAdd.Id = phoneId;
                
                _repository.AddPhone(makerId, phoneToAdd);
                _repository.Save();

                var phoneToReturn = _mapper.Map<PhoneDto>(phoneToAdd);

                return CreatedAtRoute("GetPhoneForMaker", new { makerId = makerId, phoneId = phoneToReturn.Id }, phoneToReturn);
            }

            _mapper.Map(phone, phoneFromRepo);
            _repository.UpdatePhone(phoneFromRepo);
            _repository.Save();

            return NoContent();
        }

        [HttpPatch("{phoneId}")]
        public ActionResult PartiallyUpdatePhoneForMaker(Guid makerId, Guid phoneId, [FromBody] JsonPatchDocument<PhoneForUpdatingDto> patchDocument)
        {
            if (!_repository.MakerExists(makerId))
                return NotFound();

            var phone = _repository.GetPhone(makerId, phoneId);
            if (phone is null)
            {
                var phoneDto = new PhoneForUpdatingDto();
                patchDocument.ApplyTo(phoneDto);

                var phoneToAdd = _mapper.Map<Entities.Phone>(phoneDto);
                phoneToAdd.Id = phoneId;

                _repository.AddPhone(makerId, phoneToAdd);
                _repository.Save();

                var phoneToReturn = _mapper.Map<PhoneDto>(phoneToAdd);

                return CreatedAtRoute("GetPhoneForMaker", new { makerId = makerId, phoneId = phoneToReturn.Id }, phoneToReturn);
            }

            var phoneToPatch = _mapper.Map<PhoneForUpdatingDto>(phone);
            patchDocument.ApplyTo(phoneToPatch, ModelState);

            if (!TryValidateModel(phoneToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(phoneToPatch, phone);
            _repository.UpdatePhone(phone);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{phoneId}")]
        public ActionResult DeletePhoneForMaker(Guid makerId, Guid phoneId)
        {
            if (!_repository.MakerExists(makerId))
                return NotFound();

            var phone = _repository.GetPhone(makerId, phoneId);
            if (phone is null)
                return NotFound();

            _repository.DeletePhone(phone);
            _repository.Save();

            return NoContent();

        }

        private string CreatePhonesUri(PhonesResourceParameters phonesResourceParameters, UriType uriType)
        {
            switch (uriType)
            {
                case UriType.PreviousPage:
                    return Url.Link("GetPhonesForMaker", new
                    {
                        fields = phonesResourceParameters.Fields,
                        pageNumber = phonesResourceParameters.PageNumber - 1,
                        pageSize = phonesResourceParameters.PageSize,
                        searchQuery = phonesResourceParameters.SearchQuery
                    });

                case UriType.NextPage:
                    return Url.Link("GetPhonesForMaker", new
                    {
                        fields = phonesResourceParameters.Fields,
                        pageNumber = phonesResourceParameters.PageNumber + 1,
                        pageSize = phonesResourceParameters.PageSize,
                        searchQuery = phonesResourceParameters.SearchQuery
                    });

                default:
                    return Url.Link("GetPhonesForMaker", new
                    {
                        fields = phonesResourceParameters.Fields,
                        pageNumber = phonesResourceParameters.PageNumber,
                        pageSize = phonesResourceParameters.PageSize,
                        searchQuery = phonesResourceParameters.SearchQuery
                    });
            }
        }
    }
}
