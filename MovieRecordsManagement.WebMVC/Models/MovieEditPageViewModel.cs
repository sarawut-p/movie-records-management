using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRecordsManagement.DAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRecordsManagement.WebMVC.Models
{
    public class MovieEditPageViewModel
    {
        public IEnumerable<SelectListItem> RatingListItems { get; private set; }
        public MovieViewModel MovieViewModel { get; set; }
        
        public MovieEditPageViewModel()
        {

        }

        public MovieEditPageViewModel(MovieRecord movieRecord)
        {
            this.MovieViewModel = new MovieViewModel(movieRecord);
            this.RatingListItems = MovieRecord.RATING_CONST.ALL_RAINGS
                                              .Select(rating => new SelectListItem() { Text = rating, Value = rating })
                                              .ToList();
        }
    }
}
