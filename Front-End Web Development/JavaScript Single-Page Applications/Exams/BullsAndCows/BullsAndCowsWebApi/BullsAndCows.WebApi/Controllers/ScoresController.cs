using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BullsAndCows.Data;
using System.Web.Http;
using BullsAndCows.WebApi.Models;

namespace BullsAndCows.WebApi.Controllers
{
    public class ScoresController : BaseApiController
    {
        private const int DefaultPlayersRankingCount = 10;
        
        public ScoresController() : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public ScoresController(IBullsAndCowsData data) : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
                var scores = this.data.Players.All().Select(ScoreRankModel.FromPlayer)
                                 .OrderByDescending(x => x.Rank)
                                 .ThenBy(x => x.Username)
                             .Take(DefaultPlayersRankingCount);

            return Ok(scores);
        }
    }
}