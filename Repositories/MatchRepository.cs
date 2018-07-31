using MostSnake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MostSnake.Repositories
{
    public class MatchRepository
    {
        public async Task<Match> FindMatch(int id)
        {
            using (var dbContext = ApplicationDbContext.Create())
            {
                return await Task.Run(() => dbContext.Matches.Single(m => m.MatchId == id));
            }
        }
    }
}