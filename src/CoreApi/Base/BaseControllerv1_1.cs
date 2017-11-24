using Microsoft.AspNetCore.Mvc;

namespace src
{

    [Route("v1.1/[controller]")]
    [Route("[controller]")]
    public class BaseControllerv1_1 : BaseController
    {
    }
}