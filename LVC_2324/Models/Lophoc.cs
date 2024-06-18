using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVC_2324.Models
{
    [Table("Lophoc")]
    public class Lophoc
    {
        [Key]
        public int cs { get; set; }
        public char sd { get; set; }
    }

}