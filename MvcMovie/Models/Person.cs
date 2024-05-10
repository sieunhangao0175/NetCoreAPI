using System.ComponentModel.DataAnnotations;



namespace MvcMovie.Models
{
    
    
    public class Person
    
    {
        [Key]
        public string PersonID {get; set;}
        public string fullname {get; set;}
        public string address {get; set;}
    

    }
}