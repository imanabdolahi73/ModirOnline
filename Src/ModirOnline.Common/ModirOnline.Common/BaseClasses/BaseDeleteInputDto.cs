using System.ComponentModel.DataAnnotations;

namespace ModirOnline.Common.BaseClasses
{
    public class BaseDeleteInputDto
    {
        [Required]
        public Guid DeleteByUserId { get; set; }
    }


}
