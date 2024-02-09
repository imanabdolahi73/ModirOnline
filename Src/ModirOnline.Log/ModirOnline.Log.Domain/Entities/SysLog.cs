using ModirOnline.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Log.Domain.Entities
{
    public class SysLog
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
