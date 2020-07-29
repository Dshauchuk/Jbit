using Jbit.Common.Models;
using Jbit.Models;
using Jbit.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Jbit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JbitDbContext _jbitDbContext;

        public HomeController(ILogger<HomeController> logger, JbitDbContext jbitDbContext)
        {
            _logger = logger;
            _jbitDbContext = jbitDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            try
            {
                var team = new Team(Guid.NewGuid(), "Team #1");

                var person1 = await _jbitDbContext.Persons.Include(p => p.Tasks).FirstOrDefaultAsync();
                team.AddMember(person1);

                team.TeamPersons.ElementAt(0).Person = null;
                team.TeamPersons.ElementAt(0).Team = null;

                await _jbitDbContext.Teams.AddAsync(team);
                await _jbitDbContext.SaveChangesAsync();

                var t = await _jbitDbContext.Teams.ToListAsync();
            }
            catch(Exception ex)
            {

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
