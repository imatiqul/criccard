using Exact.Criccard.Domain.Entities;

namespace Exact.Criccard.Domain.Interfaces
{
    public interface IGameService
    {
        Game MatchStart(Team firstTeam, Team secondTeam);
        Bowl Play(Team team);
    }
}
