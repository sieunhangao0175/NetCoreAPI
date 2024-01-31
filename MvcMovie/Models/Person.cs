using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace MvcMovie.Models;

public class Person
{
    public Person()
    {
    }

    public string? PersonID {get; set;}
    public string? fullname {get; set;}
    public string? address {get; set;}
    
}
