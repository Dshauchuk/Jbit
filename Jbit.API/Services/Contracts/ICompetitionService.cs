using Jbit.API.Models;
using Jbit.API.Models.ViewModels;
using Jbit.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jbit.API.Services.Contracts
{
    public interface ICompetitionService
    {
        Task<Competition> AddCompetitionAsync(CreateCompetitionModel createCompModel, UserContext userContext);
        Task<Person> AddExistentPersonIdAsync(Guid personId, Guid competitionId, UserContext userContext);
        Task<Person> AddPersonAsync(CreatePersonModel createPersonModel, UserContext userContext);
        Task<JbitTask> AddTaskAsync(CreateTaskModel createTaskModel, UserContext userContext);
        Task<Competition> GetCompetitionAsync(Guid competitionId);
        Task<Competition> GetFullCompetitionDataAsync(Guid competitionId);
        Task<List<Competition>> GetUserCompetitionsAsync(Guid userId);
    }
}