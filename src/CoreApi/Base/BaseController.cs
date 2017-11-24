using Microsoft.AspNetCore.Mvc;

namespace src
{
    [Produces("application/json")]
    [ProducesResponseType(typeof(void), 200)]
    public class BaseController : Controller
    {

    }
}