using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModirOnline.Common.Dto;
using ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto;
using ModirOnline.Common.Utility;
using ModirOnline.ProductManagement.Application.Interfaces;

namespace ModirOnline.ProductManagement.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<ApiResult>> Insert([FromBody] InsertProductCategoryInputDto inputDto)
        {
            var result = await _productCategoryService.InsertAsync(inputDto);
            Response.StatusCode = result.StatusCode;
            return result;
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ApiResult>> Update([FromBody] UpdateProductCategoryInputDto inputDto)
        {
            var result = await _productCategoryService.UpdateAsync(inputDto);
            Response.StatusCode = result.StatusCode;
            return result;
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete([FromBody] DeleteProductCategoryInputDto inputDto)
        {
            var result = await _productCategoryService.DeleteAsync(inputDto);
            Response.StatusCode = result.StatusCode;
            return result;
        }

        [HttpDelete("SoftDelete")]
        public async Task<ActionResult<ApiResult>> SoftDelete([FromBody] DeleteProductCategoryInputDto inputDto)
        {
            var result = await _productCategoryService.SoftDeleteAsync(inputDto);
            Response.StatusCode = result.StatusCode;
            return result;
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ApiResult<ProductCategoryOutputDto>>> Get([FromRoute] long id)
        {
            var result = await _productCategoryService.GetAsync(id);
            Response.StatusCode = result.StatusCode;
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResult<PaginatedList<ProductCategoryOutputDto>>>> GetAll([FromQuery] GetProductCategoryInputDto inputDto)
        {
            var result = await _productCategoryService.GetAllAsync(inputDto);
            Response.StatusCode = result.StatusCode;
            return result;
        }
    }


}
