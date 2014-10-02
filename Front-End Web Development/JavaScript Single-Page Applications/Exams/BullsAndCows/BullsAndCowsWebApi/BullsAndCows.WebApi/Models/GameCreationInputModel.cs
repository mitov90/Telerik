using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.WebApi.Models
{
    public class GameCreationInputModel
    {
        public string Name { get; set; }

        public string Number { get; set; }
    }
}