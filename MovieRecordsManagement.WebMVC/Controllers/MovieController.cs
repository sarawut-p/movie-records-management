﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRecordsManagement.DAL.Domains;
using MovieRecordsManagement.WebMVC.Models;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository;

namespace MovieRecordsManagement.WebMVC.Controllers
{
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

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(Guid id)
        {
            var movie = this._movieRecordRepository.Find(item=>item.Id==id);
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

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}