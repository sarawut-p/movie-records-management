using MovieRecordsManagement.DAL.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MovieRecordsManagement.DAL.Repositories
{
    public class MovieRecordInMemoryRepository : IRepository<MovieRecord>
    {
        private static List<MovieRecord> _movieRecords = new List<MovieRecord>()
        {
            new MovieRecord(){ MovieTitle = "Titanic", Rating = MovieRecord.RATING_CONST.PG, YearReleased = 1997 },
            new MovieRecord(){ MovieTitle = "The Matrix", Rating = MovieRecord.RATING_CONST.PG, YearReleased = 1999 },
            new MovieRecord(){ MovieTitle = "Titanic", Rating = "PG", YearReleased = 1997 }
        };

        public void Add(MovieRecord item)
        {
            _movieRecords.Add(item);
        }

        public void DeleteById(Guid id)
        {
            _movieRecords = _movieRecords.Where(movie => movie.Id != id).ToList();
        }

        public MovieRecord FindById(Guid id)
        {
            return _movieRecords.Find(item => item.Id == id);
        }

        public System.Linq.IQueryable<MovieRecord> GetAll()
        {
            return _movieRecords.AsQueryable();
        }
    }
}
