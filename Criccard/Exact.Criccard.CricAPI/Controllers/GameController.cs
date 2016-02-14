using Exact.Criccard.Domain.Entities;
using Exact.Criccard.Domain.Interfaces;
using System.Web.Http;

namespace Exact.Criccard.CricAPI.Controllers
{
    public class GameController : ApiController
    {
        private IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult CreateMatch([FromBody]Game game)
        {
            if (game == null)
                return null;
            var result = gameService.CreateMatch(game.FirstTeam, game.SecondTeam);
            return Json(result);
        }
    }
}
