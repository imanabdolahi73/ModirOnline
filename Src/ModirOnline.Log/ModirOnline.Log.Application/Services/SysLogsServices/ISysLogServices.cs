using ModirOnline.Common.Dto;
using ModirOnline.Common.Dto.SysLogsDto;
using ModirOnline.Common.Enums;
using ModirOnline.Log.Application.Interface;
using ModirOnline.Log.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Log.Application.Services.SysLogsServices
{
    public interface ISysLogServices
    {
        Task<ApiResult<IEnumerable<SysLog>>> GetSyslogs();
        Task<ApiResult> GetSyslog(string id);
        Task<ApiResult<IEnumerable<SysLog>>> GetSysLogsByClassName(string className);
        Task<ApiResult<IEnumerable<SysLog>>> GetSysLogsByFunctionName(string functionName);
        Task<ApiResult<IEnumerable<SysLog>>> GetSysLogsByLogType(LogType logType);
        Task<ApiResult<IEnumerable<SysLog>>> InnerExeception();
        Task<ApiResult> CreateSysLog(InputSysLogsDto req);
        Task<ApiResult>DeleteSyslog(string id);
        Task<ApiResult> DeleteSyslogs();
    }
    public class SysLogServices : ISysLogServices
    {
        private readonly IDataBaseContext _context;
        public SysLogServices(IDataBaseContext context)
        {
            _context=context;
        }
        public Task<ApiResult> CreateSysLog(InputSysLogsDto req)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ApiResult> DeleteSyslog(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> DeleteSyslogs()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> GetSyslog(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<IEnumerable<SysLog>>> GetSyslogs()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<IEnumerable<SysLog>>> GetSysLogsByClassName(string className)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<IEnumerable<SysLog>>> GetSysLogsByFunctionName(string functionName)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<IEnumerable<SysLog>>> GetSysLogsByLogType(LogType logType)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<IEnumerable<SysLog>>> InnerExeception()
        {
            throw new NotImplementedException();
        }
    }
}
