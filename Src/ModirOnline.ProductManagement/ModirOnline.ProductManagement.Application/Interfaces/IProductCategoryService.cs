using ModirOnline.Common.BaseInrerfaces;
using ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.ProductManagement.Application.Interfaces
{
    public interface IProductCategoryService:IBaseCrudService
        <ProductCategoryOutputDto,
        InsertProductCategoryInputDto,
        UpdateProductCategoryInputDto,
        DeleteProductCategoryInputDto, 
        GetProductCategoryInputDto,
        long>
    {
    }
}
