using MovieRecordsManagement.DAL.Domains;
using MovieRecordsManagement.WebMVC.Attrubutes;
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

        [DisplayName("Movie Title")]
        [Required]
        public string MovieTitle { get; set; }

        [DisplayName("Year Released")]
        [RangeUntilCurrentYear(1878 , ErrorMessage = "Please enter valid year")]
        [Required]
        public int YearReleased { get; set; }

        [DisplayName("Rating")]
        [Required]
        public string Rating { get; set; }

        public MovieViewModel()
        {
            this.YearReleased = DateTime.Now.Year;
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
