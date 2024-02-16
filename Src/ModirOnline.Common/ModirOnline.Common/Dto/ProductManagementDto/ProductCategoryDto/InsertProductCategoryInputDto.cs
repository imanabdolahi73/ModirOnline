using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto
{
    public class InsertProductCategoryInputDto : BaseInsertInputDto
    {
        public string Title { get; set; } = string.Empty;
    }
}
