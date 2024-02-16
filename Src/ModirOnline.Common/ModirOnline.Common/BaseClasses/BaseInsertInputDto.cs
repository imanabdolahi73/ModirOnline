using System.ComponentModel.DataAnnotations;

namespace ModirOnline.Common.BaseClasses
{
    public class BaseInsertInputDto
    {
        [Required]
        public Guid InsertByUserId { get; set; }
    }


}
