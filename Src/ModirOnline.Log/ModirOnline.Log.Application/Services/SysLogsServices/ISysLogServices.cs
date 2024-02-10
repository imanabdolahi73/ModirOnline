using ModirOnline.Common.Dto;
using ModirOnline.Common.Dto.SysLogsDto;
using ModirOnline.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Log.Application.Services.SysLogsServices
{
    public interface ISysLogServices
    {
        Task<ApiResult<IEnumerable<OutPutSysLogDto>>> GetSyslogs();
        Task<ApiResult<OutPutSysLogDto>> GetSyslog(string id);
        Task<ApiResult<IEnumerable<OutPutSysLogDto>>> GetSysLogsByClassName(string className);
        Task<ApiResult<IEnumerable<OutPutSysLogDto>>> GetSysLogsByFunctionName(string functionName);
        Task<ApiResult<IEnumerable<OutPutSysLogDto>>> GetSysLogsByLogType(LogType logType);
        Task<ApiResult<IEnumerable<OutPutSysLogDto>>> InnerExeceptions(string innerExeceptions);
        Task<ApiResult> CreateSysLog(InputSysLogsDto req);
        Task<ApiResult>DeleteSyslog(string id);
        Task<ApiResult> DeleteSyslogs();
    }
}
