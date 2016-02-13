using Exact.Criccard.Domain.Entities;
using Exact.Criccard.Domain.Interfaces;
using Newtonsoft.Json.Linq;
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

        [HttpGet]
        public IHttpActionResult CreateMatch(string game)
        {
            var gameObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Game>(game);
            if (gameObj == null)
                return null;
            var result = gameService.CreateMatch(gameObj.FirstTeam, gameObj.SecondTeam);
            return Json(result);
        }
    }
}
