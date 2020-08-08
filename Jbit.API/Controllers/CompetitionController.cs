using AutoMapper;
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
        public async Task<CompetitionViewModel> CreateCompetitionAsync(CreateCompetitionModel createModel)
        {
            var added = await _competitionService.AddCompetitionAsync(createModel, UserContext);

            return mapper.Map<CompetitionViewModel>(added);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ExtendedCompetitionViewModel> GetCompetitionByIdAsync(Guid id)
        {
            var competition = await _competitionService.GetCompetitionAsync(id);

            if (competition is null)
                throw new NotFoundException($"Competition with id '{id}' not found");

            return mapper.Map<ExtendedCompetitionViewModel>(competition);
        }

        [HttpGet()]
        public async Task<IEnumerable<CompetitionViewModel>> GetUserCompetitionsAsync([FromQuery]Guid userId)
        {
            var userCompetitions = await _competitionService.GetUserCompetitionsAsync(userId);

            return mapper.Map<IEnumerable<CompetitionViewModel>>(userCompetitions);
        }


        public async Task<IActionResult> Test()
        {


            return Ok();
        }
    }
}
