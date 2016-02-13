using Exact.Criccard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exact.Criccard.Domain.Interfaces
{
    public interface IGameService
    {
        Game CreateMatch(Team firstTeam, Team secondTeam);

    }
}
