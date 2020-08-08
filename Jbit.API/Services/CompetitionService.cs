using Jbit.API.Models;
using Jbit.API.Models.ViewModels;
using Jbit.API.Services.Contracts;
using Jbit.Common.Data;
using Jbit.Common.Exceptions;
using Jbit.Common.Models;
using Jbit.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbit.API.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly IRepository<Competition> _competitionRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<JbitTask> _taskRepository;
        private readonly IRepository<JbitExpression> _expressionRepository;

        public CompetitionService(IRepository<Competition> competitionRepository,
            IRepository<Person> personRepository,
            IRepository<JbitTask> taskRepository,
            IRepository<JbitExpression> expressionRepository)
        {
            _competitionRepository = competitionRepository;
            _personRepository = personRepository;
            _taskRepository = taskRepository;
            _expressionRepository = expressionRepository;
        }

        public async Task<Competition> AddCompetitionAsync(CreateCompetitionModel createCompModel, UserContext userContext)
        {
            Guard.IsNotNull(createCompModel);
            Guard.UserIsNotNull(userContext);
            Guard.ModelIsValid(createCompModel);

            var competition = new Competition
            {
                Name = createCompModel.Name,
                Description = createCompModel.Description,
                OwnerId = userContext.UserId
            };

            if (createCompModel.ExpressionId is null)
            {
                // create new expression
                competition.Expression = new JbitExpression(createCompModel.Name, createCompModel.Expression, createCompModel.Description);
            }
            else
            {
                // set selected expression
                var expression = await _expressionRepository.FirstOrDefaultAsync(e => e.Id == createCompModel.ExpressionId);
                if (expression is null)
                    throw new JbitException($"Expression with id '{createCompModel.ExpressionId}' not found", "expression_not_found");

                createCompModel.ExpressionId = expression.Id;
            }

            // set the user as owner
            competition.OwnerId = userContext.UserId;

            // save the competition
            var addedComp = await _competitionRepository.AddAsync(competition);
            await _competitionRepository.SaveChangesAsync();

            return addedComp;
        }

        public async Task<Person> AddExistentPersonIdAsync(Guid personId, Guid competitionId, UserContext userContext)
        {
            Guard.UserIsNotNull(userContext);

            var comp = await _competitionRepository.FirstOrDefaultAsync(c => c.Id == competitionId, q => q.Include(c => c.PersonLinks));

            if (comp is null)
                throw new JbitException($"Competition with id '{competitionId}' not found");

            if (comp.OwnerId != userContext.UserId)
                throw new ForbiddenException();

            var person = await _personRepository.FirstOrDefaultAsync(c => c.Id == personId);

            if (person is null)
                throw new JbitException($"Person with id '{personId}' not found");

            comp.PersonLinks.Add(new CompetitionPerson(comp, person));

            return person;
        }

        public async Task<Person> AddPersonAsync(CreatePersonModel createPersonModel, UserContext userContext)
        {
            Guard.IsNotNull(createPersonModel);
            Guard.UserIsNotNull(userContext);
            Guard.ModelIsValid(createPersonModel);

            var person = new Person
            {
                FirstName = createPersonModel.FirstName,
                LastName = createPersonModel.LastName,
                OwnerId = createPersonModel.OwnerId
            };

            if (createPersonModel.Competitions.Any())
            {
                var competitions = await _competitionRepository.Query(c => createPersonModel.Competitions.Any(i => i == c.Id)).ToListAsync();
                var nonExistent = createPersonModel.Competitions.Except(competitions.Select(c => c.Id));

                if (nonExistent.Any())
                    throw new JbitException($"Competition(s) with id(s) {string.Join(",", nonExistent)} do(es) not exist.");

                person.CompetitionLinks = competitions.Select(c => new CompetitionPerson { CompetitionId = c.Id, Person = person }).ToList();
            }

            var added = await _personRepository.AddAsync(person);
            await _personRepository.SaveChangesAsync();

            return added;
        }

        public async Task<JbitTask> AddTaskAsync(CreateTaskModel createTaskModel, UserContext userContext)
        {
            Guard.IsNotNull(createTaskModel);
            Guard.UserIsNotNull(userContext);
            Guard.ModelIsValid(createTaskModel);

            var person = await _personRepository
                .FirstOrDefaultAsync(p => p.Id == createTaskModel.AssignedTo);

            if (person is null)
                throw new JbitException($"Person with id '{createTaskModel.AssignedTo}' not found");

            var competition = await _competitionRepository
                .FirstOrDefaultAsync(c => c.Id == createTaskModel.CompetitionId);

            if (competition is null)
                throw new JbitException($"Competition with id '{createTaskModel.CompetitionId}' not found");

            if (competition.OwnerId != userContext.UserId)
                throw new ForbiddenException();

            // TODO: check task values for expression

            var task = new JbitTask
            {
                Title = createTaskModel.Title,
                AssignedTo = createTaskModel.AssignedTo,
                Link = createTaskModel.Link,
                Description = createTaskModel.Description,
                CompetitionId = createTaskModel.CompetitionId,
                Values = createTaskModel.Values?.Select(v => new TaskValue { Name = v.Name, Value = v.Value }).ToList()
            };

            var added = await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();

            return added;
        }

        public Task<Competition> GetCompetitionAsync(Guid competitionId)
            => _competitionRepository
                .FirstOrDefaultAsync(
                    c => c.Id == competitionId,
                    c =>
                        c.Include(a => a.PersonLinks)
                            .ThenInclude(a => a.Person)
                         .Include(a => a.Expression));

        public Task<Competition> GetFullCompetitionDataAsync(Guid competitionId)
        => _competitionRepository
                .FirstOrDefaultAsync(
                    c => c.Id == competitionId,
                    c =>
                        c.Include(a => a.PersonLinks)
                            .ThenInclude(a => a.Person)
                         .Include(a => a.TaskLinks)
                         .Include(a => a.Expression));

        public Task<List<Competition>> GetUserCompetitionsAsync(Guid userId)
            => _competitionRepository
            .Query(c => c.OwnerId == userId)
            .Include(a => a.PersonLinks)
                .ThenInclude(a => a.Person)
            .Include(a => a.Expression)
            .ToListAsync();
    }
}
