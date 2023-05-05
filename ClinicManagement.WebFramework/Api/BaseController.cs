using ClinicManagement.WebFramework.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.WebFramework.Api
{
    [ApiController]
    [ApiResultFilter]
    //[ApiVersion("1")]
    [Route("/v{version:apiVersion}/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[AutoValidateAntiforgeryToken]
    //[Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }

    [ApiController]
    [ApiResultFilter]
    //[ApiVersion("1")]
    [Route("/v{version:apiVersion}/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[AutoValidateAntiforgeryToken]
    //[Route("api/[controller]")]
    public class BaseMvcController : Controller
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}
