namespace BloggingSystem.Services.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Transactions;
    using System.Web.Http;

    using BloggingSystem.Services.Controllers;
    using BloggingSystem.Services.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json;

    [TestClass]
    public class UsersControllerTest
    {
        private InMemoryHttpServer httpServer;

        private TransactionScope scope;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            this.scope = new TransactionScope();

            var routes = new List<Route>
                             {
                                 new Route(
                                     "TagsApi", 
                                     "api/tags/{tagId}/posts", 
                                     new { controller = "tags", action = "posts" }), 
                                 new Route(
                                     "PostsApi", 
                                     "api/posts/{postId}/comment", 
                                     new { controller = "posts", action = "comment" }), 
                                 new Route("UsersApi", "api/users/{action}", new { controller = "users" }), 
                                 new Route(
                                     "DefaultApi", 
                                     "api/{controller}/{id}", 
                                     new { id = RouteParameter.Optional })
                             };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            this.scope.Dispose();
        }

        [TestMethod]
        public void TestRegisterUser_UsernameIsNull_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = null, 
                                   DisplayName = "Michael Suyama", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_UsernameIsEmpty_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = string.Empty, 
                                   DisplayName = "Michael Suyama", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_DisplayNameIsNull_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = "michael", 
                                   DisplayName = null, 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_DisplayNameIsEmpty_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = "michael", 
                                   DisplayName = string.Empty, 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_UsernameIsShorterThanMinLength_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = "mag", 
                                   DisplayName = "Margaret Peacock", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_DisplayNameIsLongerThanMaxLength_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = "margaret", 
                                   DisplayName =
                                       "Margaret Peacock Margaret Peacock Margaret Peacock Margaret Peacock", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_UsernameContainsInvalidCharacters_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = "мария", 
                                   DisplayName = "Mary Shelley", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_DisplayNameContainsInvalidCharacters_ShouldReturnBadRequest()
        {
            var testUser = new UserDto
                               {
                                   Username = "peter_petroff", 
                                   DisplayName = "Петър Петров", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_AuthCodeShorterThanSha1HashLength_ShouldReturnBadRequest()
        {
            var testUser = new UserDto { Username = "peter_petroff", DisplayName = "Peter Petroff", AuthCode = "bff" };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void TestRegisterUser_ValidData_ShouldReturnOK()
        {
            var testUser = new UserDto
                               {
                                   Username = "peter_petroff", 
                                   DisplayName = "Peter Petroff", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void TestLogoutUser_SessionKeyIsValid_ShouldReturnOK()
        {
            var testUser = new UserDto
                               {
                                   Username = "peter_petroff", 
                                   DisplayName = "Peter Petroff", 
                                   AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
                               };

            this.httpServer.Post("api/users/register", testUser);
            var response = this.httpServer.Post("api/users/login", testUser);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var loggedUser = JsonConvert.DeserializeObject<LoggedUserDto>(contentString);

            var headers = new Dictionary<string, string>();
            headers["X-SessionKey"] = loggedUser.SessionKey;

            var logoutResult = this.httpServer.Put("api/users/logout", headers);
            Assert.AreEqual(HttpStatusCode.OK, logoutResult.StatusCode);
        }

        [TestMethod]
        public void TestLogoutUser_SessionKeyIsNull_ShouldReturnOK()
        {
            var loggedUser = new LoggedUserDto { DisplayName = "Peter Petroff", SessionKey = null };

            var headers = new Dictionary<string, string>();
            headers["X-SessionKey"] = loggedUser.SessionKey;

            var logoutResult = this.httpServer.Put("api/users/logout", headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, logoutResult.StatusCode);
        }
    }
}