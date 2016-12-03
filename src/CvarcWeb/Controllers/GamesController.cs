using System.Linq;
using CvarcWeb.Data;
using CvarcWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CvarcWeb.Controllers
{
    public class GamesController : Controller
    {
        private readonly CvarcDbContext context;
        private const int GamesPerPage = 30;

        public GamesController(CvarcDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Find(GameFilterModel filters)
        {
            var games = GetGames(filters);
            var total = games.Count();
            return new JsonResult(new { games = GetPage(filters, games), total },
                                  new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        private IQueryable<Game> GetGames(GameFilterModel filters)
        {
            var foundGames = context.Games
                            .Include(g => g.TeamGameResults).ThenInclude(cgr => cgr.Team)
                            .Include(g => g.TeamGameResults).ThenInclude(cgr => cgr.Results)
                            .Where(g => string.IsNullOrEmpty(filters.GameName) || g.GameName == filters.GameName)
                            .Where(g => string.IsNullOrEmpty(filters.TeamName) || g.TeamGameResults.Any(gr => gr.Team.Name == filters.TeamName))
                            .Where(g => string.IsNullOrEmpty(filters.Region) || g.TeamGameResults.Any(gr => gr.Team.Owner.Region == filters.Region))
                            .AsQueryable();
            if (!filters.GameId.HasValue)
                return foundGames;
            return foundGames.Where(g => g.GameId == filters.GameId.Value);
        }

        private static Game[] GetPage(GameFilterModel model, IQueryable<Game> filteredGames) => 
            filteredGames.Skip(model.Page * GamesPerPage)
                         .Take(GamesPerPage)
                         .ToArray();

        [HttpGet]
        public IActionResult CreateTestDb()
        {
            if (context.Games.AsQueryable().Any(g => g.GameName == "TestGame"))
                return new ContentResult {Content = "nope!"};
            var gameResult = new Game {GameName = "TestGame", PathToLog = "C:/"};
            var firstTeam = new Team {CvarcTag = "123", LinkToImage = "qwe", Name = "Winners"};
            var secondTeam = new Team { CvarcTag = "1234", LinkToImage = "qwer", Name = "Loosers" };
            var firstTeamGameResult = new TeamGameResult {Team = firstTeam, Game = gameResult};
            var secondTeamGameResult = new TeamGameResult { Team = secondTeam, Game = gameResult};
            var result1 = new Result { TeamGameResult = firstTeamGameResult, Scores = 10, ScoresType = "MainScores"};
            var result2 = new Result { TeamGameResult = firstTeamGameResult, Scores = 20, ScoresType = "OtherScores" };
            var result3 = new Result { TeamGameResult = secondTeamGameResult, Scores = 5, ScoresType = "MainScores" };
            var result4 = new Result { TeamGameResult = secondTeamGameResult, Scores = 7, ScoresType = "OtherScores" };
            context.Games.Add(gameResult);
            context.Teams.Add(firstTeam);
            context.Teams.Add(secondTeam);
            context.TeamGameResults.Add(firstTeamGameResult);
            context.TeamGameResults.Add(secondTeamGameResult);
            context.Results.Add(result1);
            context.Results.Add(result2);
            context.Results.Add(result3);
            context.Results.Add(result4);
            context.SaveChanges();
            return new ContentResult { Content = "yep!" };
        }
    }
}
