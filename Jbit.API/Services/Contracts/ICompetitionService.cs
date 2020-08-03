using Jbit.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jbit.API.Services.Contracts
{
    public interface ICompetitionService
    {
        Task<CompetitionViewModel> AddCompetitionAsync(CreateCompetitionViewModel createCompModel);

        Task<List<CompetitionViewModel>> GetUserCompetitionsAsync(Guid userId);

        Task<ExtendedCompetitionViewModel> GetFullCompetitionDataAsync(Guid competitionId);

        Task<PersonViewModel> AddPersonAsync(CreatePersonViewModel createPersonModel);

        Task<PersonViewModel> AddExistentPersonIdAsync(Guid personId, Guid competitionId);

        Task<TaskViewModel> AddTaskAsync(CreateTaskViewModel createTaskModel);
    }
}
