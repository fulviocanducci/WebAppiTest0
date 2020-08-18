using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppiTest0.Models
{
    [Table("sources")]
    public class Source
    {
        [Key()]
        [Column("id", Order = 1)]
        public int Id { get; set; }

        [Column("description", Order = 2)]
        public string Description { get; set; }
    }
}
