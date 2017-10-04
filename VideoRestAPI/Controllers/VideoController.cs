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
    public class VideoController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/video
        [HttpGet]
        public IEnumerable<BOVideo> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BOVideo Get(int id)
        {
            return facade.VideoService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BOVideo video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.VideoService.Create(video));
        }

        // api/controllerName/id
        // api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]BOVideo video)
        {
            if(id != video.Id)
            {
                return StatusCode(405,"Path Id didn't match the Customer's Id in json object");
            }
             try
            {
				var videos = facade.VideoService.Update(video);
				return Ok(videos);
            }
            catch (Exception e)
            {
                return StatusCode(404,e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoService.Delete(id);
        }
    }
}
