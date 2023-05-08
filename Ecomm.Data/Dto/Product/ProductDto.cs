namespace Ecomm.Data.Dto.Product
{
    public record ProductDto
    {
        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
