using MovieRecordsManagement.DAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRecordsManagement.WebMVC.Models
{
    public class MovieViewModel
    {
        private MovieRecord _movieRecord;

        public string Id { get; set; }
        public string MovieTitle { get; set; }
        public int YearReleased { get; set; }
        public string Rating { get; set; }

        public MovieViewModel(MovieRecord movieRecord)
        {
            this._movieRecord = movieRecord;
            this.MovieTitle = movieRecord.MovieTitle;
            this.YearReleased = movieRecord.YearReleased;
            this.Rating = movieRecord.Rating;
        }
    }
}
