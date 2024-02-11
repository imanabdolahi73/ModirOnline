using ModirOnline.Common.Dto;
using ModirOnline.Common.Dto.SysLogsDto;
using ModirOnline.Common.Enums;
using ModirOnline.Common.Utility;
using ModirOnline.Log.Application.Interface;
using ModirOnline.Log.Domain.Entities;
using MongoDB.Driver;
using System.Net;

namespace ModirOnline.Log.Application.Services.SysLogsServices
{
    public class SysLogServices : ISysLogServices
    {
        private readonly IDataBaseContext _context;
        public SysLogServices(IDataBaseContext context)
        {
            _context=context;
        }
        public async Task<ApiResult> CreateSysLog(InsertSysLogInputDto req)
        {
            try
            {
                SysLog sysLog = new SysLog()
                {
                    StackTrace = req.StackTrace,
                    ClassName = req.ClassName,
                    FunctionName = req.FunctionName,
                    InnerException = req.InnerException,
                    LogType = req.LogType,
                    Message = req.Message,
                    UserId = req.UserId,
                };
                await _context.SysLogs.InsertOneAsync(sysLog);
                return new ApiResult
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.Created,
                    Message=Alert.GetAddAlert(Alert.Entity.SysLog)
                };
            }
            catch (Exception)
            {
                
                return new ApiResult
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
                //ersal email e or throw execption
            }
        }

        public async Task<ApiResult> DeleteSyslog(string id)
        {
            try
            {
                FilterDefinition<SysLog> filter = Builders<SysLog>.Filter.Eq(p => p.Id, id);
                DeleteResult deleteResult=await _context.SysLogs.DeleteOneAsync(filter);
                if (deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0)
                {
                    return new ApiResult
                    {
                        IsSuccess = true,
                        StatusCode = (int)HttpStatusCode.NoContent,
                        Message = Alert.GetRemoveAlert(Alert.Entity.SysLog)
                    };
                }
                throw new Exception();
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "DeleteSyslog",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
               await CreateSysLog(inputSysLogsDto);
                return new ApiResult
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult> DeleteSyslogs()
        {
            try
            {
                DeleteResult deleteResult = await _context.SysLogs.DeleteManyAsync(p => true);
                if (deleteResult.IsAcknowledged)
                {
                    return new ApiResult
                    {
                        IsSuccess = true,
                        StatusCode = (int)HttpStatusCode.NoContent,
                        Message = Alert.GetRemoveAlert(Alert.Entity.SysLog),
                    };
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "DeleteSyslogs",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult<SysLogOutputDto>> GetSyslog(string id)
        {
            try
            {
                var syslog = await _context.SysLogs.Find(p => p.Id == id).FirstOrDefaultAsync();
                if (syslog == null)
                {
                    return new ApiResult<SysLogOutputDto>
                    {
                        IsSuccess = false,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = Alert.Public.NotFound.GetDescription()
                    };
                }
                SysLogOutputDto result = new SysLogOutputDto()
                {
                    StackTrace = syslog.StackTrace,
                    FunctionName = syslog.FunctionName,
                    ClassName = syslog.ClassName,
                    Id = id,
                    InnerException = syslog.InnerException,
                    InsertDateTime = syslog.InsertDateTime,
                    LogType = syslog.LogType,
                    Message = syslog.Message,
                    UserId = syslog.UserId,
                };
                return new ApiResult<SysLogOutputDto>
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data= result,
                    Message = Alert.Public.Success.GetDescription()
                };
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "GetSyslog",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult<SysLogOutputDto>
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSyslogs()
        {
            try
            {
                var SysLogs=await _context.SysLogs.Find(p=>true).ToListAsync();
                List<SysLogOutputDto> outPutSysLogDtos = new List<SysLogOutputDto>();
                foreach (var SysLog in SysLogs)
                {
                    SysLogOutputDto outPutSysLogDto = new SysLogOutputDto()
                    {
                        StackTrace = SysLog.StackTrace,
                        ClassName = SysLog.ClassName,
                        FunctionName = SysLog.FunctionName,
                        Id = SysLog.Id,
                        InnerException = SysLog.InnerException,
                        InsertDateTime = DateTime.Now,
                        LogType = SysLog.LogType,
                        Message = SysLog.Message,
                        UserId = SysLog.UserId,
                    };
                    outPutSysLogDtos.Add(outPutSysLogDto);
                }

                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = outPutSysLogDtos,
                    Message = Alert.Public.Success.GetDescription()
                };
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "GetSyslogs",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSysLogsByClassName(string className)
        {
            try
            {
                FilterDefinition<SysLog> filter = Builders<SysLog>.Filter.Eq(p => p.ClassName, className);
                var syslogs = await _context.SysLogs.Find(filter).ToListAsync();
                List<SysLogOutputDto> outPutSysLogDtos = new List<SysLogOutputDto>();
                foreach (var SysLog in syslogs)
                {
                    SysLogOutputDto outPutSysLogDto = new SysLogOutputDto()
                    {
                        StackTrace = SysLog.StackTrace,
                        ClassName = SysLog.ClassName,
                        FunctionName = SysLog.FunctionName,
                        Id = SysLog.Id,
                        InnerException = SysLog.InnerException,
                        InsertDateTime = DateTime.Now,
                        LogType = SysLog.LogType,
                        Message = SysLog.Message,
                        UserId = SysLog.UserId,
                    };
                    outPutSysLogDtos.Add(outPutSysLogDto);
                }
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = outPutSysLogDtos,
                    Message = Alert.Public.Success.GetDescription()
                };
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "GetSysLogsByClassName",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSysLogsByFunctionName(string functionName)
        {
            try
            {
                FilterDefinition<SysLog> filter = Builders<SysLog>.Filter.Eq(p => p.FunctionName, functionName);
                var syslogs = await _context.SysLogs.Find(filter).ToListAsync();
                List<SysLogOutputDto> outPutSysLogDtos = new List<SysLogOutputDto>();
                foreach (var SysLog in syslogs)
                {
                    SysLogOutputDto outPutSysLogDto = new SysLogOutputDto()
                    {
                        StackTrace = SysLog.StackTrace,
                        ClassName = SysLog.ClassName,
                        FunctionName = SysLog.FunctionName,
                        Id = SysLog.Id,
                        InnerException = SysLog.InnerException,
                        InsertDateTime = DateTime.Now,
                        LogType = SysLog.LogType,
                        Message = SysLog.Message,
                        UserId = SysLog.UserId,
                    };
                    outPutSysLogDtos.Add(outPutSysLogDto);
                }
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = outPutSysLogDtos,
                    Message = Alert.Public.Success.GetDescription()
                };
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "GetSysLogsByFunctionName",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult<IEnumerable<SysLogOutputDto>>> GetSysLogsByLogType(LogType logType)
        {
            try
            {
                FilterDefinition<SysLog> filter=Builders<SysLog>.Filter.Eq(p=>p.LogType,logType);
                var syslogs = await _context.SysLogs.Find(filter).ToListAsync();
                List<SysLogOutputDto> outPutSysLogDtos = new List<SysLogOutputDto>();
                foreach (var SysLog in syslogs)
                {
                    SysLogOutputDto outPutSysLogDto = new SysLogOutputDto()
                    {
                        StackTrace = SysLog.StackTrace,
                        ClassName = SysLog.ClassName,
                        FunctionName = SysLog.FunctionName,
                        Id = SysLog.Id,
                        InnerException = SysLog.InnerException,
                        InsertDateTime = DateTime.Now,
                        LogType = SysLog.LogType,
                        Message = SysLog.Message,
                        UserId = SysLog.UserId,
                    };
                    outPutSysLogDtos.Add(outPutSysLogDto);
                }
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = outPutSysLogDtos,
                    Message = Alert.Public.Success.GetDescription()
                };
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "GetSysLogsByLogType",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ApiResult<IEnumerable<SysLogOutputDto>>> InnerExeceptions(string innerExeceptions)
        {
            try
            {
                FilterDefinition<SysLog> filter = Builders<SysLog>.Filter.Eq(p => p.InnerException, innerExeceptions);
                var syslogs = await _context.SysLogs.Find(filter).ToListAsync();
                List<SysLogOutputDto> outPutSysLogDtos = new List<SysLogOutputDto>();
                foreach (var SysLog in syslogs)
                {
                    SysLogOutputDto outPutSysLogDto = new SysLogOutputDto()
                    {
                        StackTrace = SysLog.StackTrace,
                        ClassName = SysLog.ClassName,
                        FunctionName = SysLog.FunctionName,
                        Id = SysLog.Id,
                        InnerException = SysLog.InnerException,
                        InsertDateTime = DateTime.Now,
                        LogType = SysLog.LogType,
                        Message = SysLog.Message,
                        UserId = SysLog.UserId,
                    };
                    outPutSysLogDtos.Add(outPutSysLogDto);
                }
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = outPutSysLogDtos,
                    Message = Alert.Public.Success.GetDescription()
                };
            }
            catch (Exception e)
            {

                InsertSysLogInputDto inputSysLogsDto = new InsertSysLogInputDto()
                {
                    InnerException = e.InnerException.ToString(),
                    StackTrace = e.StackTrace,
                    ClassName = "SysLogServices",
                    FunctionName = "GetSysLogsByLogType",
                    LogType = LogType.Error,
                    Message = e.Message,
                    UserId = "Exception IN log Service",
                };
                await CreateSysLog(inputSysLogsDto);
                return new ApiResult<IEnumerable<SysLogOutputDto>>
                {
                    IsSuccess = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }
    }
}
