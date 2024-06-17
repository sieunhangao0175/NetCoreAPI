using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVC_BaiThi2324.Models
{
    [Table("Employee")]
    public class Employee : Person
    {
        [Key]
        public int personID { get; set; }
        public string ten { get; set;}
        public char Adress { get; set; }

    }
}
