using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [Route("v1.1/[controller]")]
    public class TodoController : BaseControllerv1_1
    {
        // GET api/values
        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Add a new todo.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="200">We have created your todo.</response>
        /// <response code="400">Your model is invalid</response>
        /// <response code="500">Something is wrong on our server. But we don't know what cause it.</response>
        [ProducesResponseType(typeof(Return), 200)]
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }


        // DELETE api/values/5
        [Obsolete("This endpoint is deprecated. Please use Put and send an Id to delete it.")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
