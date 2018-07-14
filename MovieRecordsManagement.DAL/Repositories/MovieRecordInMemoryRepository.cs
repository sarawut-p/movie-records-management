using MovieRecordsManagement.DAL.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository;

namespace MovieRecordsManagement.DAL.Repositories
{
    public class MovieRecordInMemoryRepository
    {
        static IRepository<MovieRecord,Guid> InMemoryMovieRecordRepository;

        private MovieRecordInMemoryRepository() {

        }

        public static IRepository<MovieRecord, Guid> getInstance()
        {
            if(InMemoryMovieRecordRepository == null)
            {
                InMemoryMovieRecordRepository = new InMemoryRepository<MovieRecord,Guid>();
                InMemoryMovieRecordRepository.Add(new MovieRecord() { MovieTitle = "Titanic", Rating = MovieRecord.RATING_CONST.G, YearReleased = 2017 });
            }

            return InMemoryMovieRecordRepository;
        }
    }
}
