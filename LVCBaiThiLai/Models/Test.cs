using System.ComponentModel.DataAnnotations.Schema;

namespace LVCBaiThiLai.Models
{
    [Table("Test")]
    public class LVCBaiThiLai
    {
        public string Name { get; set;}
        public int Description { get; set;}
    }
}
