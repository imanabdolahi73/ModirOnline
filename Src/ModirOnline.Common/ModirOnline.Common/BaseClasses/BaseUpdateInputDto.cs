using System.ComponentModel.DataAnnotations;

namespace ModirOnline.Common.BaseClasses
{
    public class BaseUpdateInputDto
    {
        [Required]
        public Guid UpdateByUserId { get; set; }
    }


}
