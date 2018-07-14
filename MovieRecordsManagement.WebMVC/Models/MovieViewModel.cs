using MovieRecordsManagement.DAL.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRecordsManagement.WebMVC.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string MovieTitle { get; set; }

        [DisplayName("Year Released")]
        [Required]
        public int YearReleased { get; set; }

        [DisplayName("Rating")]
        [Required]
        public string Rating { get; set; }

        public MovieViewModel()
        {

        }

        public MovieViewModel(MovieRecord movieRecord)
        {
            this.Id = movieRecord.Id;
            this.MovieTitle = movieRecord.MovieTitle;
            this.YearReleased = movieRecord.YearReleased;
            this.Rating = movieRecord.Rating;
        }
    }
}
