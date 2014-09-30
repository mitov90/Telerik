using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WebApi.Models
{
    public class ScoreRankModel
    {
         public static Expression<Func<Player, ScoreRankModel>> FromPlayer
        {
            get
            {
                return player => new ScoreRankModel
                {
                   Username = player.Name,
                   Rank = player.Rank
                };
            }
        }
        public string Username { get; set; }
        public int Rank { get; set; }
    }
}