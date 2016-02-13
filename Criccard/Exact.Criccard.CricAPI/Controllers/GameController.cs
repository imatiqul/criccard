using Exact.Criccard.Domain.Entities;
using Exact.Criccard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Exact.Criccard.CricAPI.Controllers
{
    public class GameController : ApiController
    {
        private IGameService gameService;
        public GameController()
        {
            //TODO: Make an Application Instance to get AppSettings
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CriccardModel"].ToString();
            this.gameService = new Services.GameService(connectionString);
        }

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost]
        [ResponseType(typeof(Game))]
        public IHttpActionResult CreateMatch(Game game)
        {

            //Team firstTeam = new Team
            //{
            //    Name = "Atiq",
            //    IsBowlFirst = true
            //}, secondTeam = new Team { Name = "Shuvo" };
            var result = gameService.CreateMatch(game.FistTeam, game.SecondTeam);
            return Json(result);
        }
    }
}
