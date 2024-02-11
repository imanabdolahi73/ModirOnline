using ModirOnline.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Common.Dto.SysLogsDto
{
    public class InsertSysLogInputDto
    {
        public LogType LogType { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string? ClassName { get; set; }
        public string? FunctionName { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? InnerException { get; set; }
        public string? StackTrace { get; set; }
    }
}
