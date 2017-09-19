using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideosMenuBLL;
using VideosMenuBLL.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
		BLLFacade facade = new BLLFacade();
        // GET: api/values
        [HttpGet]
        public IEnumerable<BOGenre> Get()
        {
            return facade.GenreService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BOGenre Get(int id)
        {
            return facade.GenreService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BOGenre genre)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
            return Ok(facade.GenreService.Create(genre));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BOGenre genre)
        {
            if (id != genre.Id)
			{
				return StatusCode(405, "Path Id didn't match the Customer's Id in json object");
			}
			try
			{
                var genreUpdated = facade.GenreService.Update(genre);
				return Ok(genreUpdated);
			}
			catch (Exception e)
			{
				return StatusCode(404, e.Message);
			}
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
            facade.RentalService.Delete(id);
        }
    }
}
