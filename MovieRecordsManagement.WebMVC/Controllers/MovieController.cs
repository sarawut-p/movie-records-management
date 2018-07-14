using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRecordsManagement.DAL.Domains;
using MovieRecordsManagement.WebMVC.Models;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository;

namespace MovieRecordsManagement.WebMVC.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private IRepository<MovieRecord, Guid> _movieRecordRepository;

        public MovieController(IRepository<MovieRecord,Guid> movieRecordRepository)
        {
            this._movieRecordRepository = movieRecordRepository;            
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movieViewModels = this._movieRecordRepository.GetAll().Select(item => new MovieViewModel(item));
            return View(movieViewModels);
        }


        // GET: Movie/Create
        public ActionResult Create()
        {
            var viewModel = new MovieEditPageViewModel(new MovieRecord());
            return View(viewModel);
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieEditPageViewModel viewModel)
        {
            try
            {
                var movie = new MovieRecord();
                movie.MovieTitle = viewModel.MovieViewModel.MovieTitle;
                movie.Rating = viewModel.MovieViewModel.Rating;
                movie.YearReleased = viewModel.MovieViewModel.YearReleased;
                _movieRecordRepository.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(Guid? id)
        {
            var movie = _movieRecordRepository.Find(item=>item.Id==id);
            return View(new MovieEditPageViewModel(movie));
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieEditPageViewModel viewModel)
        {
            try
            {
                var movieModel = this._movieRecordRepository.Find(item => item.Id == viewModel.MovieViewModel.Id);
                movieModel.MovieTitle = viewModel.MovieViewModel.MovieTitle;
                movieModel.Rating = viewModel.MovieViewModel.Rating;
                movieModel.YearReleased = viewModel.MovieViewModel.YearReleased;
                this._movieRecordRepository.Update(movieModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var movie = this._movieRecordRepository.Find(item => item.Id == id);
            return View(new MovieViewModel(movie));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MovieViewModel movieViewModel)
        {
            try
            {
                this._movieRecordRepository.Delete(movieViewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}