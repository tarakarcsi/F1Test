using F1Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Test.Interfaces
{
    public interface ITeamSvc
    {
        List<Team> LoadTeams();
    }
}
