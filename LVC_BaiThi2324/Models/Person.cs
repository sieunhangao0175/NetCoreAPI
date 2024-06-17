using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVC_BaiThi2324.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int personID { get; set; }
        public string Name { get; set;}
        public char Adress { get; set; }

    }
}
