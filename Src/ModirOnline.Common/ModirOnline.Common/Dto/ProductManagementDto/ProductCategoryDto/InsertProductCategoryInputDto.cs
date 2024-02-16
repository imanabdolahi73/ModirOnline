using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModirOnline.Common.BaseClasses;

namespace ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto
{
    public class InsertProductCategoryInputDto : BaseInsertInputDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
