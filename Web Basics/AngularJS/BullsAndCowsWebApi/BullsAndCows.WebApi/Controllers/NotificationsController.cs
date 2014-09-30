using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BullsAndCows.Data;
using BullsAndCows.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.WebApi.Models;
using System.Net.Http;

namespace BullsAndCows.WebApi.Controllers
{
    public class NotificationsController : BaseApiController
    {
        private const string WinMessageTemplate = "You beat {0} in game \"{1}\"";
        private const string LoseMessageTemplate = "{0} beat you in game \"{1}\"";
        private const string JoinGameMessageTemplate = "{0} joined your game \"{1}\"";
        private const string YourTurnMessageTemplate = "It's your turn in game \"{0}\"";

        private const int DefaultPageSize = 10;

        public NotificationsController() : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
            //TODO Add Ninject
        }

        public NotificationsController(IBullsAndCowsData data) : base(data)
        {
        }
        
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetByPage(int page)
        {
            var playerId = this.User.Identity.GetUserId();
            var player = this.data.Players.All().FirstOrDefault(p => p.UserId == playerId);
            
            var notifications = this.GetNotificationsByPage(page, player.Id);
            return Ok(notifications);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var playerId = this.User.Identity.GetUserId();
            var player = this.data.Players.All().FirstOrDefault(p => p.UserId == playerId);
            
            var notifications = this.GetNotificationsByPage(0, player.Id);
            return Ok(notifications);
        }

        [Authorize]
        [Route("api/notifications/Next")]
        [HttpGet]
        public IHttpActionResult Next()
        {
            var playerId = this.User.Identity.GetUserId();
            var player = this.data.Players.All().FirstOrDefault(p => p.UserId == playerId);

            var notification = this.data.Notifications.All().Where(n => n.PlayerId == player.Id && n.State == NotificationState.Unread)
                                   .OrderByDescending(x => x.DateCreated)
                                   .Take(1)
                                   .Select(NotificationModel.FromNotification).FirstOrDefault();
            
            if (notification == null)
            {
                var message = new HttpResponseMessage(System.Net.HttpStatusCode.NotModified);
                return ResponseMessage(message);
            }

            var notificationInDb = this.data.Notifications.Find(notification.Id);
            notificationInDb.State = NotificationState.Read;
            this.data.SaveChanges();
            
            return Ok(notification);
        }

        [NonAction]
        public static Notification SendNotification(Game game, int playerId, NotificationType type)
        {
            // TODO Modify
            if (!(game.BluePlayerId == playerId || game.RedPlayerId == playerId))
            {
                throw new ArgumentException("Player is not part of the game!");
            }
            Notification notification;
            Player enemyPlayer = game.BluePlayerId == playerId ? game.RedPlayer : game.BluePlayer;
            switch (type)
            {
                case NotificationType.GameJoined:
                    {
                        var message = string.Format(JoinGameMessageTemplate, enemyPlayer.Name, game.Name);
                        notification = new Notification() { Message = message, GameId = game.Id, PlayerId = playerId, Type = NotificationType.GameJoined, DateCreated = DateTime.Now, State = NotificationState.Unread, };
                    }
                    break;
                case NotificationType.YourTurn:
                    {
                        var message = string.Format(YourTurnMessageTemplate, game.Name);
                        notification = new Notification() { Message = message, GameId = game.Id, PlayerId = playerId, Type = NotificationType.YourTurn, DateCreated = DateTime.Now, State = NotificationState.Unread, };
                    }
                    break;
                case NotificationType.GameWon:
                    {
                        var message = string.Format(WinMessageTemplate, enemyPlayer.Name, game.Name);
                        notification = new Notification() { Message = message, GameId = game.Id, PlayerId = playerId, Type = NotificationType.GameWon, DateCreated = DateTime.Now, State = NotificationState.Unread, };
                    }
                    break;
                case NotificationType.GameLost:
                    {
                        var message = string.Format(LoseMessageTemplate, enemyPlayer.Name, game.Name);
                        notification = new Notification() { Message = message, GameId = game.Id, PlayerId = playerId, Type = NotificationType.GameLost, DateCreated = DateTime.Now, State = NotificationState.Unread, };
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return notification;
        }

        private ICollection<NotificationModel> GetNotificationsByPage(int page, int playerId)
        {
            var notifications = this.data.Notifications.All()
                                    .Where(n => n.PlayerId == playerId)
                                    .OrderByDescending(x => x.DateCreated)
                                    .Skip(page * DefaultPageSize)
                                    .Take(DefaultPageSize)
                                    .Select(NotificationModel.FromNotification).ToList();
            return notifications;
        }
    }
}