using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhonesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using PhonesAPI.Helpers;
using PhonesAPI.Models;

namespace PhonesAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/makercollections")]
    [ResponseCache(CacheProfileName = "MainCacheProfile")]
    [ApiVersion("1.0")]
    public class MakerCollectionsController : ControllerBase
    {
        private readonly IMakerPhoneRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerRepository _loggerRepository;

        public MakerCollectionsController(IMakerPhoneRepository repository, 
            IMapper mapper,
            ILoggerRepository loggerRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _loggerRepository = loggerRepository;

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public ActionResult<IEnumerable<MakerDto>> CreateMakerCollection([FromBody] IEnumerable<MakerForCreatingDto> makerCollection)
        {
            var makerEntities = _mapper.Map<IEnumerable<Entities.Maker>>(makerCollection);

            foreach (var maker in makerEntities)
            {
                _repository.AddMaker(maker);
            }

            _repository.Save();
            var makerCollectionToReturn = _mapper.Map<IEnumerable<MakerDto>>(makerEntities);
            var idsString = string.Join(",", makerCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetMakerCollection", new { ids = idsString }, makerCollectionToReturn);
        }

        [HttpGet("({ids})", Name = "GetMakerCollection")]
        public IActionResult GetMakerCollection([FromRoute] 
                                                [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids is null)
            {
                _loggerRepository.LogError("GetMakerCollection, ids is null");
                return BadRequest();
            }

            var makerEntities = _repository.GetMakers(ids);

            if (ids.Count() != makerEntities.Count())
                return NotFound();

            var makersToReturn = _mapper.Map<IEnumerable<MakerDto>>(makerEntities);

            return Ok(makersToReturn);
        }
    }
}
