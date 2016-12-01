using System.Linq;
using CvarcWeb.Data;
using CvarcWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CvarcWeb.Controllers
{
    public class GamesController : Controller
    {
        private CvarcDbContext context;
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
        public JsonResult Get(GameFilterModel model)
        {
            var queryableGames = context.Games
                .Include(g => g.TeamGameResults).ThenInclude(cgr => cgr.Team)
                .Include(g => g.TeamGameResults).ThenInclude(cgr => cgr.Results)
                .AsQueryable();
            if (model == null)
                return new JsonResult(new {games=queryableGames.Take(GamesPerPage).ToArray(), total=queryableGames.Count()});

            if (!string.IsNullOrEmpty(model.GameName))
                queryableGames = queryableGames.Where(g => g.GameName == model.GameName);
            if (!string.IsNullOrEmpty(model.TeamName))
                queryableGames = queryableGames.Where(g => g.TeamGameResults.Any(cgr => cgr.Team.Name == model.TeamName));
            if (!string.IsNullOrEmpty(model.Region))
                queryableGames = queryableGames.Where(g => g.TeamGameResults.Any(cgr => cgr.Team.Owner.Region == model.Region));

            var total = queryableGames.Count();
            queryableGames = queryableGames.Skip(model.Page * GamesPerPage);
            var games = queryableGames.Take(GamesPerPage).ToArray();

            return new JsonResult(new { games,total }, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
        }

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
