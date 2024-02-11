using ModirOnline.Common.Enums;

namespace ModirOnline.Common.Dto.SysLogsDto
{
    public class SysLogOutputDto
    {
        public string Id { get; set; }
        public LogType LogType { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
        public string? ClassName { get; set; }
        public string? FunctionName { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? InnerException { get; set; }
        public string? StackTrace { get; set; }
    }
}
