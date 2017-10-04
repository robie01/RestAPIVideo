using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VideosMenuBLL;
using VideosMenuBLL.BO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RentalController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/rental
        [HttpGet]
        public IEnumerable<BORental> Get()
        {
            return facade.RentalService.GetAll().ToList();
        }

        // GET api/rental/5
        [HttpGet("{id}")]
        public BORental Get(int id)
        {
            return facade.RentalService.Get(id);
        }

        // POST api/rental
        [HttpPost]
        public IActionResult Post([FromBody]BORental rent)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
                return Ok(facade.RentalService.Create(rent));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BORental rent)
        {
			if (id != rent.Id)
			{
				return StatusCode(405, "Path Id didn't match the Customer's Id in json object");
			}
			try
			{
                var rental = facade.RentalService.Update(rent);
				return Ok(rental);
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
