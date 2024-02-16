namespace ModirOnline.Common.Dto.ProductManagementDto.ProductCategoryDto
{
    public class UpdateProductCategoryInputDto : BaseUpdateInputDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
