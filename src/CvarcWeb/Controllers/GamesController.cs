using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CvarcWeb.Data;
using CvarcWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CvarcWeb.Controllers
{
    public class GamesController : Controller
    {
        private CvarcDbContext context;

        public GamesController(CvarcDbContext context)
        {
            this.context = context;
        }

        public JsonResult Get()
        {
            var game = context.Games.Include(g => g.CommandGameResults).First();
            dynamic heh = new { res = game.CommandGameResults.ToArray()};
            return new JsonResult(heh);
        }

        [HttpGet]
        public IActionResult CreateTestDb()
        {
            if (context.Games.AsQueryable().Any(g => g.GameName == "TestGame"))
                return new ContentResult {Content = "nope!"};
            var gameResult = new Game {GameName = "TestGame", PathToLog = "C:/"};
            var firstCommand = new Command {CvarcTag = "123", LinkToImage = "qwe", Name = "Winners"};
            var secondCommand = new Command { CvarcTag = "1234", LinkToImage = "qwer", Name = "Loosers" };
            var firstCommandGameResult = new CommandGameResult {Command = firstCommand, Game = gameResult};
            var secondCommandGameResult = new CommandGameResult { Command = secondCommand, Game = gameResult };
            var result1 = new Result {CommandGameResult = firstCommandGameResult, Scores = 10, ScoresType = "MainScores"};
            var result2 = new Result { CommandGameResult = firstCommandGameResult, Scores = 20, ScoresType = "OtherScores" };
            var result3 = new Result { CommandGameResult = secondCommandGameResult, Scores = 5, ScoresType = "MainScores" };
            var result4 = new Result { CommandGameResult = secondCommandGameResult, Scores = 7, ScoresType = "OtherScores" };
            context.Games.Add(gameResult);
            context.Commands.Add(firstCommand);
            context.Commands.Add(secondCommand);
            context.CommandGameResults.Add(firstCommandGameResult);
            context.CommandGameResults.Add(secondCommandGameResult);
            context.Results.Add(result1);
            context.Results.Add(result2);
            context.Results.Add(result3);
            context.Results.Add(result4);
            context.SaveChanges();
            return new ContentResult { Content = "yep!" };
        }

        [HttpGet]
        public IActionResult ReadTestDb()
        {
            var cgr = context.CommandGameResults.First();
            var game = context.Games.Include(g => g.CommandGameResults).First(c => c.GameName == "TestGame");
            return new ContentResult {Content = $"{game.CommandGameResults.First().Results.Count} {cgr.Game.GameName}"};
        }
    }
}
