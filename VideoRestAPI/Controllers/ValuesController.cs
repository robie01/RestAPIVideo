using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideosMenuBLL.BO;

namespace VideoRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        // R in CRUD
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // R in CRUD 
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value -- " + id;
        }

        // POST api/values
        // BO comes from JSON using ModelBinding
        [HttpPost]
        public void Post([FromBody]BOVideo video)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
