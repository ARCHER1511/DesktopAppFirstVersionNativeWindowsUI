namespace ERPAppDomain.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public string FileName { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
    }
}
