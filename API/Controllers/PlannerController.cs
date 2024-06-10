using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PlannerController : BaseApiController
    {
        private readonly IPlannerRepository _plannerRepository;
        private readonly IMapper _mapper;

        public PlannerController(IPlannerRepository plannerRepository, IMapper mapper)
        {
            _plannerRepository = plannerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Planner>> GetPlannerById(string id)
        {
            var planner = await _plannerRepository.GetPlannerAsync(id);

            return Ok(planner ?? new Planner(id));
        }
        [HttpPost]
        public async Task<ActionResult<Planner>> UpdatePlanner(Planner planner)
        {
            

            var UpdatedPlanner = await _plannerRepository.UpdatePlannerAsync(planner);

            return Ok(UpdatedPlanner);
        }

        [HttpDelete]
        public async Task DeletePlannerAsync(string id)
        {
            await _plannerRepository.DeletePlannerAsync(id);
        }
    }
}
