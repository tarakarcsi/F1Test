using F1Test.Interfaces;
using F1Test.Models;
using System.Collections.Generic;

namespace F1Test.Services
{
    public class TeamSvc : ITeamSvc
    {
        public List<Team> LoadTeams()
        {
            return DatabaseContext.LoadTeams();
        }
    }
}
