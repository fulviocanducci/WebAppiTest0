using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppiTest0.Models
{
    [Table("credits")]
    public class Credit
    {
        [Key()]
        [Column("id", Order = 1)]
        public int Id { get; set; }

        [Column("title", Order = 2)]
        public string Title { get; set; }
    }
}
