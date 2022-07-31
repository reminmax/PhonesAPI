using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using AutoMapper;
using PhonesAPI.Helpers;
using PhonesAPI.Models;
using PhonesAPI.Services;

namespace PhonesAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ResponseCache(CacheProfileName = "MainCacheProfile")]
    [ApiVersion("1.0")]
    public class MakersController : ControllerBase
    {
        private readonly IMakerPhoneRepository _repository;
        private readonly ILoggerRepository _loggerRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly IPropertyValidationService _propertyValidationService;

        public MakersController(IMakerPhoneRepository repository,
            ILoggerRepository loggerRepository,
            IMapper mapper,
            IPropertyMappingService propertyMappingService,
            IPropertyValidationService propertyValidationService)
        {
            _repository = repository ?? 
                          throw new ArgumentNullException(nameof(repository));

            _loggerRepository = loggerRepository ??
                                throw new ArgumentNullException(nameof(loggerRepository));

            _mapper = mapper ?? 
                      throw new ArgumentNullException(nameof(mapper));

            _propertyMappingService = propertyMappingService ?? 
                                      throw new ArgumentNullException(nameof(propertyMappingService));

            _propertyValidationService = propertyValidationService ?? 
                                         throw new ArgumentNullException(nameof(propertyValidationService));
        }

        public ActionResult<IEnumerable<MakerDto>> GetMakers()
        {
            var makers = _repository.GetMakers();

            _loggerRepository.LogInfo("GetMakers");

            return Ok(_mapper.Map<IEnumerable<MakerDto>>(makers));
        }

        [HttpGet(Name = "GetMakers")]
        [HttpHead]
        public IActionResult GetMakers([FromQuery] MakersResourceParameters makersResourceParameters)
        {
            if (!_propertyMappingService.ValidMappingExists<MakerDto, Entities.Maker>
                    (makersResourceParameters.OrderBy))
            {
                _loggerRepository.LogError("GetMakers, BadRequest");
                return BadRequest();
            }

            if (!_propertyValidationService.HasValidProperties<MakerDto>
                    (makersResourceParameters.Fields))
            {
                _loggerRepository.LogError("GetMakers, BadRequest");
                return BadRequest();
            }

            var makers = _repository.GetMakers(makersResourceParameters);

            var previuosPageLink = 
                makers.HasPrevious ? CreateMakersUri(makersResourceParameters, UriType.PreviousPage) : null;

            var nextPageLink =
                makers.HasNext ? CreateMakersUri(makersResourceParameters, UriType.NextPage) : null;

            var metaData = new
            {
                totalCount = makers.TotalCount,
                pageSize = makers.PageSize,
                currentPage = makers.CurrentPage,
                totalPages = makers.TotalPages,
                previuosPageLink = previuosPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metaData));

            _loggerRepository.LogInfo("GetMakers");

            return Ok(_mapper.Map<IEnumerable<MakerDto>>(makers)
                .ShapeData(makersResourceParameters.Fields));
        }

        [HttpGet("{makerId}", Name = "GetMaker")]
        public IActionResult GetMaker(Guid makerId, string fields)
        {
            if (!_propertyValidationService.HasValidProperties<MakerDto>(fields))
            {
                _loggerRepository.LogError("GetMaker, BadRequest");
                return BadRequest();
            }

            var maker = _repository.GetMaker(makerId);
            
            if (maker is null)
                return NotFound();

            _loggerRepository.LogInfo("GetMaker");

            return Ok(_mapper.Map<MakerDto>(maker).ShapeData(fields));
        }

        [HttpPost]
        public ActionResult<MakerDto> CreateMaker([FromBody] MakerForCreatingDto maker)
        {
            var makerEntity = _mapper.Map<Entities.Maker>(maker);
            _repository.AddMaker(makerEntity);
            _repository.Save();

            var makerToReturn = _mapper.Map<MakerDto>(makerEntity);

            _loggerRepository.LogInfo("CreateMaker");

            return CreatedAtRoute("GetMaker", new { makerId = makerToReturn.Id }, makerToReturn);
        }

        [HttpOptions]
        public IActionResult GetMakersOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,DELETE,HEAD,OPTIONS");
            
            _loggerRepository.LogInfo("GetMakersOptions");

            return Ok();
        }

        [HttpDelete("{makerId}")]
        public ActionResult DeleteMaker(Guid makerId)
        {
            var maker = _repository.GetMaker(makerId);
            if (maker is null)
            {
                _loggerRepository.LogError("DeleteMaker, Maker not found");
                return NotFound();
            }

            _repository.DeleteMaker(maker);
            _repository.Save();

            _loggerRepository.LogInfo("DeleteMaker");

            return NoContent();
        }

        private string CreateMakersUri(MakersResourceParameters makersResourceParameters, UriType uriType)
        {
            switch (uriType)
            {
                case UriType.PreviousPage:
                    return Url.Link("GetMakers", new
                    {
                        fields = makersResourceParameters.Fields,
                        pageNumber = makersResourceParameters.PageNumber - 1,
                        pageSize = makersResourceParameters.PageSize,
                        searchQuery = makersResourceParameters.SearchQuery
                    });

                case UriType.NextPage:
                    return Url.Link("GetMakers", new
                    {
                        fields = makersResourceParameters.Fields,
                        pageNumber = makersResourceParameters.PageNumber + 1,
                        pageSize = makersResourceParameters.PageSize,
                        searchQuery = makersResourceParameters.SearchQuery
                    });
                
                default:
                    return Url.Link("GetMakers", new
                    {
                        fields = makersResourceParameters.Fields,
                        pageNumber = makersResourceParameters.PageNumber,
                        pageSize = makersResourceParameters.PageSize,
                        searchQuery = makersResourceParameters.SearchQuery
                    });
            }
        }
    }
}
