using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModirOnline.Log.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SysLogsController : ControllerBase
    {
        [HttpPost("InputSysLogsDto")]
        public ActionResult CreateLog()
        {
            return null;
        }
    }
}
