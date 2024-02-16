using Microsoft.EntityFrameworkCore;
using ModirOnline.Common.Dto;
using ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto;
using ModirOnline.Common.Enums;
using ModirOnline.Common.Utility;
using ModirOnline.ProductManagement.Application.Interfaces;
using ModirOnlline.ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.ProductManagement.Application.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IDbContextProductManagement _context;
        public ProductCategoryService(IDbContextProductManagement context)
        {
            _context = context;
        }
        public async Task<ApiResult> DeleteAsync(DeleteProductCategoryInputDto inputDto)
        {
            try
            {
                var productCategory = _context.ProductCategories.Where(p => p.Id == inputDto.Id).FirstOrDefault();

                if (productCategory is null)
                {
                    return new ApiResult
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }

                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();

                return new ApiResult
                {
                    IsSuccess = true,
                    Message = Alert.GetDeleteAlert(Alert.Entity.ProductCategory),
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log for ex
                return new ApiResult
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ApiResult<ProductCategoryOutputDto>> GetAsync(long id)
        {
            try
            {
                var outputDto = await _context.ProductCategories.Where(p => p.Id == id)
                    .Select(p => new ProductCategoryOutputDto
                    {
                        Id = p.Id,
                        Title = p.Title
                    }).FirstOrDefaultAsync();
                
                if (outputDto is null)
                {
                    return new ApiResult<ProductCategoryOutputDto>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }

                return new ApiResult<ProductCategoryOutputDto>
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = outputDto
                };
            }
            catch (Exception ex)
            {
                return new ApiResult<ProductCategoryOutputDto>
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ApiResult<PaginatedList<ProductCategoryOutputDto>>> GetAllAsync(GetProductCategoryInputDto inputDto)
        {
            try
            {
                IQueryable<ProductCategoryOutputDto> query = _context.ProductCategories
                    .Where(p => !p.IsDeleted)
                    .Select(p=> new ProductCategoryOutputDto
                    {
                        Id = p.Id,
                        Title = p.Title
                    });

                if (!string.IsNullOrEmpty(inputDto.Title))
                {
                    query = query.Where(p => p.Title.Contains(inputDto.Title));
                }

                if (query.Count() == 0)
                {
                    return new ApiResult<PaginatedList<ProductCategoryOutputDto>>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }

                return new ApiResult<PaginatedList<ProductCategoryOutputDto>>
                {
                    IsSuccess = true,
                    Data =await PaginatedList<ProductCategoryOutputDto>.Create(query, inputDto.PageIndex, inputDto.PageSize),
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResult<PaginatedList<ProductCategoryOutputDto>>
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ApiResult> InsertAsync(InsertProductCategoryInputDto inputDto)
        {
            try
            {
                ProductCategory productCategory = new ProductCategory
                {
                    Title = inputDto.Title,
                    InsertByUserId = inputDto.InsertByUserId,
                    InsertDateTime = DateTime.Now
                };

                _context.ProductCategories.Add(productCategory);
                await _context.SaveChangesAsync();

                return new ApiResult
                {
                    IsSuccess = true,
                    Message = Alert.GetInsertAlert(Alert.Entity.ProductCategory),
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log for ex
                return new ApiResult
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ApiResult> SoftDeleteAsync(DeleteProductCategoryInputDto inputDto)
        {
            try
            {
                var productCategory = _context.ProductCategories.Where(p => p.Id == inputDto.Id).FirstOrDefault();

                if (productCategory is null)
                {
                    return new ApiResult
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }
                productCategory.IsDeleted = true;
                productCategory.DeleteByUserId = inputDto.DeleteByUserId;
                productCategory.DeleteDateTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new ApiResult
                {
                    IsSuccess = true,
                    Message = Alert.GetDeleteAlert(Alert.Entity.ProductCategory),
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log for ex
                return new ApiResult
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ApiResult> UpdateAsync(UpdateProductCategoryInputDto inputDto)
        {
            try
            {
                var productCategory = _context.ProductCategories.Where(p => p.Id == inputDto.Id).FirstOrDefault();

                if (productCategory is null)
                {
                    return new ApiResult
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }
                productCategory.Title = inputDto.Title;
                productCategory.UpdateByUserId = inputDto.UpdateByUserId;
                productCategory.UpdateDateTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new ApiResult
                {
                    IsSuccess = true,
                    Message = Alert.GetUpdateAlert(Alert.Entity.ProductCategory),
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                //log for ex
                return new ApiResult
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
