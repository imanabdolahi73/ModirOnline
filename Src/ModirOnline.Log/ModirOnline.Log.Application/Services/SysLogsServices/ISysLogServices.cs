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
        Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSyslogs();
        Task<ApiResult<SysLogOutputDto>> GetSyslog(string id);
        Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSysLogsByClassName(string className);
        Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSysLogsByFunctionName(string functionName);
        Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSysLogsByLogType(LogType logType);
        Task<ApiResult<IEnumerable<SysLogOutputDto>>> InnerExeceptions(string innerExeceptions);
        Task<ApiResult> CreateSysLog(InsertSysLogInputDto req);
        Task<ApiResult>DeleteSyslog(string id);
        Task<ApiResult> DeleteSyslogs();
    }
}
