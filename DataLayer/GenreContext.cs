using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GenreContext : IDb<Genre, int>
    {
        DBContext dBContext;

        public GenreContext(DBContext dBContext_)
        {
            this.dBContext = dBContext_;
        }

        public void Create(Genre genre)
        {
            try
            {
                dBContext.Genres.Add(genre);
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
                Genre genreFromDB = Read(key);
                dBContext.Genres.Remove(genreFromDB);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Genre Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Genres.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Genres.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Genre item, bool useNavigationalProperties = false)
        {
            try
            {
                dBContext.Genres.Update(item);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
