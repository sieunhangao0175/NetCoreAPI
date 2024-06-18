using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVC_2324.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public char Name { get; set; }
        public string? adress { get; set; }
    }
    
}