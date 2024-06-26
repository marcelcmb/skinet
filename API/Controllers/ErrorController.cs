using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)] // ignore this in Swagger because of the "ambiguous error"
    public class ErrorController : BaseApiController
    {

        // this is for {{url}}/api/endpointthatdoesnotexist
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
