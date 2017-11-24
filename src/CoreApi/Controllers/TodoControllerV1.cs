using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [Route("v1/[controller]")]
    public class TodoControllerV1 : TodoController
    {
        /// <summary>
        /// This method deprecated please use new v1.1
        /// </summary>
        [Produces("application/xml")]
        [HttpGet]
        [Obsolete]
        public override IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }
    }
}
