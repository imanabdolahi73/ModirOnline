using System.ComponentModel.DataAnnotations;
using ModirOnline.Common.BaseClasses;

namespace ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto
{
    public class DeleteProductCategoryInputDto : BaseDeleteInputDto
    {
        [Required]
        public long Id { get; set; }
    }
}
