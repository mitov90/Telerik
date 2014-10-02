using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BullsAndCows.Data;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.Models;
using BullsAndCows.WebApi.Models;
using System.Net;

namespace BullsAndCows.WebApi.Controllers
{
    public class GamesController : BaseApiController
    {
        private const int DefaultPageSize = 10;
        private const int MaximumNumberOfDifferentDigits = 8;
        private const int MaximumNumberOfBulls = 4;

        public GamesController() : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public GamesController(IBullsAndCowsData data) : base(data)
        {
        }
        
        [Authorize]
        [HttpPost]
        public IHttpActionResult Guess(int gameId, [FromBody]
                                       string number)
        {
            var game = this.data.Games.Find(gameId);
            var player = this.GetAuthenticatedPlayer();
            if (game == null)
            {
                return BadRequest("Such game does not exist!");
            }
            
            if (!(game.RedPlayerId == player.Id || game.BluePlayerId == player.Id))
            {
                return BadRequest("You are not part of this game!");
            }

            if (game.GameState == GameState.WaitingForOpponent)
            {
                return BadRequest("The game has not yet started. Waiting for blue player!");
            }

            if (game.GameState == GameState.GameOver)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            Guess guess;

            //TODO FUCKIN REFACTOR!!!!
            if (game.RedPlayerId == player.Id && game.GameState == GameState.RedInTurn)
            {
                var bulls = this.GetNumberOfBulls(number, game.BluePlayerNumber);
                var cows = MaximumNumberOfDifferentDigits - this.GetNumberOfDifferentDigits(number, game.BluePlayerNumber) - bulls;
                
                guess = new Guess() { Bulls = bulls, Cows = cows, GameId = gameId, GuessNumber = number, DateCreated = DateTime.Now, PlayerId = player.Id };

                if (bulls == MaximumNumberOfBulls)
                {
                    game.GameState = GameState.GameOver;

                    var winnerNotification = NotificationsController.SendNotification(game, game.RedPlayer.Id, NotificationType.GameWon);
                    var loserNotification = NotificationsController.SendNotification(game, game.BluePlayer.Id, NotificationType.GameLost);

                    game.RedPlayer.WonGames += 1;
                    game.BluePlayer.LostGames += 1;
                    this.UpdateUserRank(game.RedPlayer);
                    this.UpdateUserRank(game.BluePlayer);
                    this.data.Notifications.Add(winnerNotification);
                    this.data.Notifications.Add(loserNotification);
                    this.data.SaveChanges();
                }
                else
                {
                    game.GameState = GameState.BlueInTurn;
                    var notification = NotificationsController.SendNotification(game, game.BluePlayer.Id, NotificationType.YourTurn);
                    this.data.Notifications.Add(notification);
                    this.data.SaveChanges();
                }

                this.data.Guesses.Add(guess);
                this.data.SaveChanges();
            }
            else if (game.BluePlayerId == player.Id && game.GameState == GameState.BlueInTurn)
            {
                var bulls = this.GetNumberOfBulls(number, game.RedPlayerNumber);
                var cows = MaximumNumberOfDifferentDigits - this.GetNumberOfDifferentDigits(number, game.RedPlayerNumber) - bulls;

                guess = new Guess() { Bulls = bulls, Cows = cows, GameId = gameId, GuessNumber = number, DateCreated = DateTime.Now, PlayerId = player.Id };

                if (bulls == MaximumNumberOfBulls)
                {
                    game.GameState = GameState.GameOver;
                    
                    var loserNotification = NotificationsController.SendNotification(game, game.RedPlayer.Id, NotificationType.GameLost);
                    var winnerNotification = NotificationsController.SendNotification(game, game.BluePlayer.Id, NotificationType.GameWon);
               
                    game.BluePlayer.WonGames += 1;
                    game.RedPlayer.LostGames += 1;
                    this.UpdateUserRank(game.RedPlayer);
                    this.UpdateUserRank(game.BluePlayer);
                    this.data.Notifications.Add(winnerNotification);
                    this.data.Notifications.Add(loserNotification);
                    this.data.SaveChanges();
                }
                else
                {
                    game.GameState = GameState.RedInTurn;
                    var notification = NotificationsController.SendNotification(game, game.RedPlayer.Id, NotificationType.YourTurn);
                    this.data.Notifications.Add(notification);
                    this.data.SaveChanges();
                }

                this.data.Guesses.Add(guess);
                this.data.SaveChanges();
            }
            else
            {
                return BadRequest("It's not your turn!");
            }

            var guessModel = this.data.Guesses.All().Where(g => g.Id == guess.Id).Select(GuessModel.FromGuess);
            return Ok(guessModel);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Such game does not exist!");
            }
            var player = this.GetAuthenticatedPlayer();
            if (!(game.RedPlayerId == player.Id || game.BluePlayerId == player.Id))
            {
                return BadRequest("You are not part of this game!");
            }
            if (game.GameState == GameState.WaitingForOpponent)
            {
                return BadRequest("The game has not yet started. Waiting for blue player!");
            }
            if (game.GameState == GameState.GameOver)
            {
               return StatusCode(HttpStatusCode.Forbidden);
            }
            var gameDetails = this.data.Games.All().Where(x => x.Id == id).Select(game.RedPlayer.Id == player.Id ? GameDetailsModel.FromGameRedPlayer : GameDetailsModel.FromGameBluePlayer).FirstOrDefault();

            return Ok(gameDetails);
        }

        [HttpGet]
        public IHttpActionResult GetByPage(int page)
        {
            ICollection<GameCreatedModel> games;
            if (this.User.Identity.IsAuthenticated)
            {
                games = this.GetGamesByPage(page, true);
            }
            else
            {
                games = this.GetGamesByPage(page, false);
            }
            
            return Ok(games);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult JoinGame(int id, [FromBody]
                                          string number)
        {
            var game = this.data.Games.Find(id);
            var player = this.GetAuthenticatedPlayer();
            if (game == null)
            {
                return BadRequest("Such game does not exist!");
            }
            if (game.GameState != GameState.WaitingForOpponent)
            {
                return BadRequest("The game is not available for joining!");
            }
            if (!IsNumberValid(number))
            {
                return BadRequest("Invalid number! Please enter a 4 digit number with non-repeating digits.");
            }
            game.BluePlayer = player;
            game.BluePlayerNumber = number;
            game.GameState = rand.Next(0, 2) == 1 ? GameState.RedInTurn : GameState.BlueInTurn;
            this.data.SaveChanges();
            var gameModel = this.data.Games.All().Where(g => g.Id == id).Select(GameCreatedModel.FromGame).FirstOrDefault();
            return Ok(gameModel);
        }
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ICollection<GameCreatedModel> games;
            if (this.User.Identity.IsAuthenticated)
            {
                games = this.GetGamesByPage(0, true);
            }
            else
            {
                games = this.GetGamesByPage(0, false);
            }
            
            return Ok(games);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create([FromBody]
                                        GameCreationInputModel inputModel)
        {
            var number = inputModel.Number;
            var name = inputModel.Name;
            if (!IsNumberValid(number))
            {
                return BadRequest("Input number is not in the correct format! Please enter a 4 digit, non repeating sequence!");
            }

            var userId = this.User.Identity.GetUserId();
            var player = this.GetPlayerByUserId(userId);

            var game = new Game() { DateCreated = DateTime.Now, Name = name, RedPlayer = player, RedPlayerId = player.Id, GameState = GameState.WaitingForOpponent, RedPlayerNumber = number };
            this.data.Games.Add(game);
            this.data.SaveChanges();

            var gameModel = new GameCreatedModel()
            {
                Id = game.Id,
                Name = game.Name,
                Red = game.RedPlayer.Name,
                Blue = "No blue player yet",
                DateCreated = game.DateCreated,
                GameState = game.GameState.ToString()
            };
            return Ok(gameModel);
        }

        private int GetNumberOfBulls(string secretNumber, string guessNumber)
        {
            if (secretNumber.Length != guessNumber.Length)
            {
                throw new ArgumentException("Lengths of the two numbers dont match!");
            }
            int bulls = 0;
            for (int i = 0; i < secretNumber.Length; i++)
            {
                if (secretNumber[i] == guessNumber[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }

        private int GetNumberOfDifferentDigits(string secretNumber, string guessNumber)
        {
            if (secretNumber.Length != guessNumber.Length)
            {
                throw new ArgumentException("Lengths of the two numbers dont match!");
            }
            var digits = new HashSet<char>();

            for (int i = 0; i < secretNumber.Length; i++)
            {
                digits.Add(secretNumber[i]);
                digits.Add(guessNumber[i]);
            }

            return digits.Count;
        }

        private ICollection<GameCreatedModel> GetGamesByPage(int page, bool isUserAuthenticated)
        {
            IQueryable<Game> games;
            if (isUserAuthenticated)
            {
                var player = this.GetAuthenticatedPlayer();
                games = this.data.Games.All().Where(g => (g.GameState == GameState.WaitingForOpponent) || (((g.BluePlayerId == player.Id) ^ (g.RedPlayerId == player.Id)) && g.BluePlayerId != null && g.GameState != GameState.GameOver)); // No ordering by game state because we take only the games with state that is 'Waiting for opponent'
            }
            else
            {
                games = this.data.Games.All().Where(g => g.GameState == GameState.WaitingForOpponent); 
            }
            var queriedGames = games.OrderByDescending(g => g.GameState)
                                    .ThenBy(g => g.Name)
                                    .ThenBy(g => g.DateCreated)
                                    .ThenBy(g => g.RedPlayer.Name)
                                    .Skip(page * DefaultPageSize)
                                    .Take(DefaultPageSize)
                                    .Select(GameCreatedModel.FromGame)
                                    .ToList();

            return queriedGames;
        }

        private Player GetPlayerByUserId(string userId)
        {
            var player = this.data.Players.All().FirstOrDefault(p => p.UserId == userId);
            if (player == null)
            {
                throw new ArgumentException("Such player does not exist!");
            }
            return player;
        }

        private Player GetAuthenticatedPlayer()
        {
            var playerId = this.User.Identity.GetUserId();
            var player = this.GetPlayerByUserId(playerId);
            return player;
        }

        private bool IsNumberValid(string number)
        {
            if (number.Length != MaximumNumberOfBulls)
            {
                return false;
            }

            for (int i = 0; i < number.Length; i++)
            {
                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[i] == number[j])
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        private void UpdateUserRank(Player player)
        {
            var rank = 100 * player.WonGames + 15 * player.LostGames;
            player.Rank = rank;
            this.data.Players.Update(player);
            this.data.SaveChanges();
        }
    }
}