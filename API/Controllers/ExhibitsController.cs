using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Helpers;

namespace API.Controllers
{

    public class ExhibitsController : BaseApiController
    {
        private readonly IGenericRepository<Exhibits> _exhibitsRepo;
        private readonly IGenericRepository<ExhibitCulture> _exhibitCultureRepo;
        private readonly IGenericRepository<ExhibitType> _exhibitTypeRepo;
        private readonly IMapper _mapper;

        public ExhibitsController(IGenericRepository<Exhibits> exhibitsRepo,
        IGenericRepository<ExhibitCulture> exhibitCultureRepo, IGenericRepository<ExhibitType>
        exhibitTypeRepo, IMapper mapper)
        {
            _exhibitsRepo = exhibitsRepo;
            _exhibitCultureRepo = exhibitCultureRepo;
            _exhibitTypeRepo = exhibitTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ExhibitToReturnDto>>> GetExhibits(
            [FromQuery] ExhibitsSpecParams exhibitParams)
        {
            var spec = new ExhibitsWithCultureAndTypesSpecification(exhibitParams);
            var countSpec = new ExhibitsWithCultureAndTypesSpecification(exhibitParams);

            var totalItems = await _exhibitsRepo.CountAsync(countSpec);
            var exhibits = await _exhibitsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Exhibits>, IReadOnlyList<ExhibitToReturnDto>>(exhibits);

            return Ok(new Pagination<ExhibitToReturnDto>(exhibitParams.PageIndex, exhibitParams.PageSize, totalItems, data));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExhibitToReturnDto>> GetExhibit(int id)
        {
            var spec = new ExhibitsWithCultureAndTypesSpecification(id);
            var exhibit = await _exhibitsRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Exhibits, ExhibitToReturnDto>(exhibit);
        }

        [HttpGet("cultures")]
        public async Task<ActionResult<IReadOnlyList<ExhibitCulture>>> GetExhibitCultureAsync()
        {
            return Ok(await _exhibitCultureRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ExhibitType>>> GetExhibitTypes()
        {
            return Ok(await _exhibitTypeRepo.ListAllAsync());
        }
    }
}
