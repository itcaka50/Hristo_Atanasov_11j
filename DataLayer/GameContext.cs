using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GameContext : IDb<Game, int>
    {
        DBContext dBContext;

        public GameContext(DBContext dBContext_)
        {
            this.dBContext = dBContext_;
        }

        public void Create(Game game)
        {
            try
            {
                dBContext.Games.Add(game);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                Game gameFromDB = Read(key);
                dBContext.Games.Remove(gameFromDB);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Game Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Games.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Games.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Game item, bool useNavigationalProperties = false)
        {
            try
            {
                dBContext.Games.Update(item);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
