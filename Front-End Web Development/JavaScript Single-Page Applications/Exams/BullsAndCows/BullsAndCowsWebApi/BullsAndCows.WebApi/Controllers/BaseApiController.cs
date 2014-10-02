using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BullsAndCows.Data;

namespace BullsAndCows.WebApi.Controllers
{
  //  [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected IBullsAndCowsData data;
        protected static Random rand;
        protected BaseApiController(IBullsAndCowsData data)
        {
            this.data = data;
        }
        static BaseApiController()
        {
            rand = new Random();
        }
    }
}