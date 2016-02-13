using Exact.Criccard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exact.Criccard.Domain.Entities;
using System.Data.Entity;

namespace Exact.Criccard.Services
{
    public class GameService : IGameService
    {
        private string connectionString = string.Empty;

        public GameService(string conString)
        {
            connectionString = conString;
        }
        public Game CreateMatch(Team firstTeam, Team secondTeam)
        {
            //TODO:
            using (var context = new CriccardModel(this.connectionString))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var gameID = Guid.NewGuid();
                        context.Teams.Add(firstTeam);
                        context.Teams.Add(secondTeam);
                        context.Games.Add(new Game { FirstTeam = firstTeam, SecondTeam = secondTeam, Status = Domain.EnumCollections.GameStatus.Start, ID = gameID });
                        context.SaveChanges();
                        transaction.Commit();
                        return context.Games.FirstOrDefault(g => g.ID == gameID);
                    }
                    catch (Exception e)
                    {
                        //TODO: Log Write
                        transaction.Rollback();
                    }
                }
            }
            return null;
        }
    }
}
