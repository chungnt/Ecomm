using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Data.Entities
{
    public class BaseEntity
    {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; } = string.Empty;
        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
        [Column("updated_by")]
        public string? UpdatedBy { get; set; }
    }
}
