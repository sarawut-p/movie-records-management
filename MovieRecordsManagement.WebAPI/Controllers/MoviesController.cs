using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRecordsManagement.DAL.Domains;
using MovieRecordsManagement.DAL.Repositories;

namespace MovieRecordsManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IRepository<MovieRecord> _movieRecordRepository;

        public MoviesController(IRepository<MovieRecord> movieRecordRepository)
        {
            this._movieRecordRepository = movieRecordRepository;
        }
        
        [HttpGet]
        public IEnumerable<MovieRecord> Get()
        {
            return this._movieRecordRepository.GetAll();
        }

        [HttpGet("{id}")]
        public MovieRecord Get(Guid id)
        {
            return this._movieRecordRepository.FindById(id);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this._movieRecordRepository.DeleteById(id);
        }
    }
}
