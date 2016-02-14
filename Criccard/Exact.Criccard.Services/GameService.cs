using Exact.Criccard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exact.Criccard.Domain.Entities;
using System.Data.Entity;
using log4net;

namespace Exact.Criccard.Services
{
    public class GameService : IGameService
    {
        private static ILog log = LogManager.GetLogger(typeof(GameService));
        private string connectionString = string.Empty;

        public GameService(string conString)
        {
            connectionString = conString;
        }
        public Game MatchStart(Team firstTeam, Team secondTeam)
        {
            //TODO:
            using (var context = new CriccardModel(this.connectionString))
            {

                //var firstTeamExists = context.Teams.FirstOrDefault(t => t.Name.ToLower() == firstTeam.Name.ToLower());
                //var secondTeamExists = context.Teams.FirstOrDefault(t => t.Name.ToLower() == secondTeam.Name.ToLower());
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var gameID = Guid.NewGuid();
                        //if (firstTeamExists == null)
                        //{
                        //    context.Teams.Add(firstTeam);
                        //    log.Debug(string.Format("{0} - Team Added", firstTeam.Name));
                        //}
                        //else
                        //{
                        //    firstTeamExists.IsBowlFirst = firstTeam.IsBowlFirst;
                        //    context.Teams.Attach(firstTeamExists);
                        //    context.Entry(firstTeamExists).State = EntityState.Modified;
                        //}

                        //if (secondTeamExists == null)
                        //{
                        //    context.Teams.Add(secondTeam);
                        //    log.Debug(string.Format("{0} - Team Added", secondTeam.Name));
                        //}
                        //else
                        //{
                        //    secondTeamExists.IsBowlFirst = secondTeam.IsBowlFirst;
                        //    context.Teams.Attach(secondTeamExists);
                        //    context.Entry(secondTeamExists).State = EntityState.Modified;
                        //}

                        //TODO: Language changes needed
                        context.Teams.Add(firstTeam);
                        context.Teams.Add(secondTeam);
                        //context.Games.Add(new Game { FirstTeam = firstTeamExists == null ? firstTeam : firstTeamExists, SecondTeam = secondTeamExists == null ? secondTeam : secondTeamExists, Status = Domain.EnumCollections.GameStatus.Start, ID = gameID, Language = Domain.EnumCollections.Language.English });
                        context.Games.Add(new Game { FirstTeam = firstTeam, SecondTeam = secondTeam, Status = Domain.EnumCollections.GameStatus.Start, ID = gameID, Language = Domain.EnumCollections.Language.English });
                        context.SaveChanges();
                        transaction.Commit();
                        log.Debug(string.Format("Game ID#{0} Created", gameID));
                        return context.Games.FirstOrDefault(g => g.ID == gameID);
                    }
                    catch (Exception e)
                    {
                        log.Error("Failed to create match", e);
                        transaction.Rollback();
                    }
                }
            }
            return null;
        }

        public Bowl Play(Team team)
        {
            using (var context = new CriccardModel(this.connectionString))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var over = GetOver(context, team);
                        if (over != null)
                        {
                            var newBowl = new Bowl { Over = over, Number = 1 };

                            var lastBowl = context.Bowls.Where(b => b.Over.Team.ID == team.ID
                            && b.Over.OverNumber == over.OverNumber)
                                .OrderByDescending(b => b.Number).FirstOrDefault();

                            if (lastBowl != null && (lastBowl.Number < 6 || (lastBowl.Number >= 6 && lastBowl.IsWide)))
                            {
                                newBowl.Number = lastBowl.Number + 1;
                            }

                            //Random Run
                            Random rnd = new Random();
                            newBowl.Run = rnd.Next(-1, 6);

                            if (newBowl.Run == -1)
                            {
                                newBowl.Run = 1;
                                newBowl.IsWide = true;
                            }

                            context.Bowls.Add(newBowl);
                            context.SaveChanges();
                            transaction.Commit();
                            return context.Bowls.Where(b => b.Over.Team.ID == team.ID
                            && b.Over.OverNumber == over.OverNumber
                            && b.Number == newBowl.Number).FirstOrDefault();
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error("Failed to create match", e);
                        transaction.Rollback();
                    }
                }
            }

            return null;
        }

        private Over GetOver(CriccardModel context, Team team)
        {
            var teamExists = context.Teams.FirstOrDefault(t => t.ID == team.ID);
            var lastOver = context.Overs.Include(o => o.Team)
                .Where(o => o.Team.ID == team.ID)
                .OrderByDescending(o => o.OverNumber).FirstOrDefault();

            if (teamExists != null)
            {
                if (lastOver != null)
                {
                    var lastBowl = context.Bowls.Include(b => b.Over)
                        .Where(b => b.Over.Team.ID == team.ID
                        && b.Over.ID == lastOver.ID)
                        .OrderByDescending(b => b.Number).FirstOrDefault();

                    if (lastBowl != null && (lastBowl.Number < 6 || (lastBowl.Number >= 6 && lastBowl.IsWide)))
                    {
                        return lastOver;
                    }
                }

                var newOver = new Over { OverNumber = 1, Team = teamExists };
                if (lastOver != null)
                {
                    newOver.OverNumber = lastOver.OverNumber + 1;
                }
                //TODO: Get Six Overs Boundary from AppSettings
                if (newOver.OverNumber <= 6)
                {
                    return context.Overs.Add(newOver);
                }
            }
            return null;
        }
    }
}
