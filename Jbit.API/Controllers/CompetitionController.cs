using AutoMapper;
using Jbit.API.Models;
using Jbit.API.Models.ViewModels;
using Jbit.API.Services.Contracts;
using Jbit.Common.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jbit.API.Controllers
{
    [Route("api/competitions")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompetitionController : BaseController
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(IMapper mapper, 
            IHttpContextAccessor httpContextAccessor,
            ICompetitionService competitionService) 
            : base(mapper, httpContextAccessor)
        {
            _competitionService = competitionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetitionAsync(CreateCompetitionModel createModel)
        {
            var added = await _competitionService.AddCompetitionAsync(createModel, UserContext);

            return Created(string.Empty, mapper.Map<CompetitionViewModel>(added));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCompetitionByIdAsync(Guid id)
        {
            var competition = await _competitionService.GetFullCompetitionDataAsync(id);

            if (competition is null)
                throw new NotFoundException($"Competition with id '{id}' not found");

            return Ok(mapper.Map<ExtendedCompetitionViewModel>(competition));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCompetitionsAsync([FromQuery]Guid userId)
        {
            var userCompetitions = await _competitionService.GetUserCompetitionsAsync(userId);

            return Ok(mapper.Map<IEnumerable<CompetitionViewModel>>(userCompetitions));
        }

        [HttpPost("{competitionId:Guid}/persons")]
        public async Task<IActionResult> CreatePersonAsync([FromRoute]Guid competitionId, [FromBody]CreatePersonModel personModel)
        {
            if (personModel != null)
                personModel.CompetitionId = competitionId;

            var addedPerson = await _competitionService.AddPersonAsync(personModel, UserContext);

            return Created(string.Empty, mapper.Map<PersonViewModel>(addedPerson));
        }

        [HttpPost("{competitionId:Guid}/persons/{personId}")]
        public async Task<IActionResult> CreateTaskAsync([FromRoute] Guid competitionId, [FromRoute] Guid personId, [FromBody] CreateTaskModel taskModel)
        {
            if(taskModel != null)
            {
                taskModel.CompetitionId = competitionId;
                taskModel.AssignedTo = personId;
            }

            var addedTask = await _competitionService.AddTaskAsync(taskModel, UserContext);

            return Ok(mapper.Map<TaskViewModel>(addedTask));
        }
    }
}
