using ModirOnline.Common.Dto;
using ModirOnline.Common.Utility;

namespace ModirOnline.Common.BaseInrerfaces
{
    public interface IBaseCrudService<TOutputDto, TInsertInputDto, TUpdateInputDto,TDeleteInputDto,TGetAllInputDto, TId>
        where TOutputDto : class
        where TInsertInputDto : class
        where TUpdateInputDto : class
    {
        Task<ApiResult> InsertAsync(TInsertInputDto inputDto);
        Task<ApiResult> UpdateAsync(TUpdateInputDto inputDto);
        Task<ApiResult> DeleteAsync(TDeleteInputDto inputDto);
        Task<ApiResult> SoftDeleteAsync(TDeleteInputDto inputDto);
        Task<ApiResult<TOutputDto>> GetAsync(TId id);
        Task<ApiResult<PaginatedList<TOutputDto>>> GetAllAsync(TGetAllInputDto inputDto);
    }
}
