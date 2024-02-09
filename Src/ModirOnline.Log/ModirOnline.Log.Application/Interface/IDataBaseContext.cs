using ModirOnline.Log.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Log.Application.Interface
{
    public interface IDataBaseContext
    {
        IMongoCollection<SysLog> SysLogs { get; }
    }
}
