namespace Ecomm.Data.Dto.Product
{
    public class ProductInsertDto
    {
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
