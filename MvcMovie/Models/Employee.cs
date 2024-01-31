using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace MvcMovie.Models;

public class Employee : Person
{
    public string? EmployeeID { get; set;}
    public int Age{get; set;}


}