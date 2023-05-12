using BussinessLayer;
using DataLayer;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    [TestFixture]
    public class GameContextTest
    {
        private GameContext context = new(SetupFixture.dbContext);
        private Game game;
        private User user;
        private Genre genre;

        [SetUp]
        public void Setup()
        {
            game = new(1, "Colaja adventures");

            user = new(2, "Georgi", "Colov", 18, "ChovekaBloonz", "AnnieLuluZoeLover", "coleto@coleto.com");

            genre = new(3, "Adventure Romance");

            game.users.Add(user);
            game.genres.Add(genre);

            context.Create(game);
        }

        [TearDown]
        public void DropGames()
        {
            foreach (Game item in SetupFixture.dbContext.Games.ToList())
            {
                SetupFixture.dbContext.Games.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            Game testGame = new(4, "Colaja adventures");

            int gamesBefore = SetupFixture.dbContext.Games.Count();

            context.Create(testGame);

            int gamesAfter = SetupFixture.dbContext.Games.Count();

            Assert.That(gamesBefore + 1 == gamesAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            Game readGame = context.Read(game.Game_id);

            Assert.AreEqual(game, readGame, "Read does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            Game readGame = context.Read(game.Game_id);
            Assert.That(readGame.users.Contains(user)
                && readGame.genres.Contains(genre),
                "user and genre are not in the User and Genre list!");
        }

        [Test]
        public void ReadAll()
        {
            List<Game> games = (List<Game>)context.ReadAll();

            Assert.That(games.Count != 0, "ReadAll() does not return cupboards!");
        }

        [Test]
        public void ReadAllWithNavigationalProperties()
        {
            Game readGame = new(6, "Colaja adventures");
            User user2 = new(5, "Georgi", "Colov", 18, "ChovekaBloonz", "AnnieLuluZoeLover", "coleto@coleto.com");
            SetupFixture.dbContext.Users.Add(user2);
            SetupFixture.dbContext.Games.Add(readGame);
            context.Create(readGame);

            List<Game> games = (List<Game>)context.ReadAll();

            Assert.That(games.Count != 0
                && context.Read(readGame.Game_id).users.Count == 1, "ReadAll() does not return users!");
        }

        [Test]
        public void Update()
        {
            Game changedGame = context.Read(game.Game_id);

            changedGame.Game_name = "COLAJACRAFT";

            context.Update(changedGame);

            Assert.AreEqual(changedGame, game, "Update() does not work!");
        }

        [Test]
        public void Delete()
        {
            int gamesBefore = SetupFixture.dbContext.Games.Count();

            context.Delete(game.Game_id);
            int gamesAfter = SetupFixture.dbContext.Games.Count();

            Assert.IsTrue(gamesBefore - 1 == gamesAfter, "Delete() does not work!");
        }
    }
}

        