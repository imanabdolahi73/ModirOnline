using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Common.Dto
{
    public class BaseEntity<T>
    {
        public T Id { get;set; }
        public Guid InsertByUserId { get; set; }
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
        public Guid? UpdateByUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public Guid? DeleteByUserId { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
