using ModirOnline.Common.Dto;
using ModirOnline.Common.Utility;

namespace ModirOnline.Common.BaseInrerfaces
{
    public interface IBaseCrudService<TOutputDto, TInsertInputDto, TUpdateInputDto, TId>
        where TOutputDto : class
        where TInsertInputDto : class
        where TUpdateInputDto : class
    {
        ApiResult Insert(TInsertInputDto inputDto);
        ApiResult Update(TUpdateInputDto inputDto);
        ApiResult Delete(TId id);
        ApiResult<TOutputDto> Get(TId id);
        ApiResult<PaginatedList<TOutputDto>> GetAll();
    }
}
