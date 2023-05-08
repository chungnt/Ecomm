using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Data.Entities
{
    [Table("product")]

    public record Product : BaseEntity
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("sku")]
        public string Sku { get; set; } = string.Empty;
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("description")]
        public string? Description { get; set; }
    }
}
