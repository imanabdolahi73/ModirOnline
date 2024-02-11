using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModirOnline.Common.Dto;
using ModirOnline.Common.Dto.SysLogsDto;
using ModirOnline.Common.Enums;
using ModirOnline.Log.Application.Services.SysLogsServices;

namespace ModirOnline.Log.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SysLogsController : ControllerBase
    {
        private readonly ISysLogServices _syslog;
        public SysLogsController(ISysLogServices sysLogServices)
        {
            _syslog = sysLogServices;
        }
        [HttpPost("InsertSysLogInputDto")]
        public async Task<ActionResult<ApiResult>> CreateLog(InsertSysLogInputDto InputSysLogsDto)
        {
            var result =await _syslog.CreateSysLog(InputSysLogsDto);
            Response.StatusCode = result.StatusCode;
           return result;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<IEnumerable<SysLogOutputDto>>>> GetLogs()
        {
            var result=await _syslog.GetSyslogs();
            Response.StatusCode = result.StatusCode;
            Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
            return result;
        }
        [HttpDelete("id")]
        public async Task<ActionResult<ApiResult>> DeleteLog(string id)
        {
            var result = await _syslog.DeleteSyslog(id);
            Response.StatusCode = result.StatusCode;
            return result;
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResult>> DeleteLogs()
        {
            var result=await _syslog.DeleteSyslogs();
            Response.StatusCode = result.StatusCode;
            return result;
        }
        [HttpGet("className")]
        public async Task<ActionResult<ApiResult<IEnumerable<SysLogOutputDto>>>> GetLogsFromClassName(string className)
        {
            var result=await _syslog.GetSysLogsByClassName(className);
            Response.StatusCode = result.StatusCode;
            Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
            return result;
        }
        [HttpGet("functionName")]
        public async Task<ActionResult<ApiResult<IEnumerable<SysLogOutputDto>>>> GetLogsFromfunctionName(string functionName)
        {
            var result = await _syslog.GetSysLogsByFunctionName(functionName);
            Response.StatusCode = result.StatusCode;
            Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
            return result;
        }
        [HttpGet("logType")]
        public async Task<ActionResult<ApiResult<IEnumerable<SysLogOutputDto>>>> GetLogsFromLogType(LogType logType)
        {
            var result = await _syslog.GetSysLogsByLogType(logType);
            Response.StatusCode = result.StatusCode;
            Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
            return result;
        }
        [HttpGet("innerExeceptions")]
        public async Task<ActionResult<ApiResult<IEnumerable<SysLogOutputDto>>>> GetLogsFromInnerExeceptions(string innerExeceptions)
        {
            var result = await _syslog.InnerExeceptions(innerExeceptions);
            Response.StatusCode = result.StatusCode;
            Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
            return result;
        }
        [HttpGet("id")]
        public async Task<ActionResult<ApiResult<SysLogOutputDto>>> GetLogsFromId(string id)
        {
            var result = await _syslog.GetSyslog(id);
            Response.StatusCode = result.StatusCode;
            return result;
        }
    }
}
