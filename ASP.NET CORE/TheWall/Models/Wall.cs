using System;
using System.ComponentModel.DataAnnotations;
namespace TheWall.Models{

public class BaseEntity{

}
public class User : BaseEntity{
    public string first_name{get;set;}
    public string last_name{get;set;}
    public string email{get;set;}
    public string password{get;set;}
    public DateTime created_at{get;set;}
    public DateTime updated_at{get;set;}
}
public class RegisterViewModel : BaseEntity{
    [Required]
    [MinLength(2)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
    public string first_name{get;set;}
    [Required]
    [MinLength(2)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
    public string last_name{get;set;}
    [Required]
    [EmailAddress]
    public string email{get;set;}
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string password{get;set;}
    [DataType(DataType.Password)]
    [Compare("password", ErrorMessage = "Passwords do not match, please try again!")]
    public string cpassword{get;set;}

}
public class login : BaseEntity{
    [Required]
    [EmailAddress]
    public string email{get;set;}
    [Required]
    [DataType(DataType.Password)]
    public string password{get;set;}
}
public class messages{
    [Required]
    [DataType(DataType.MultilineText)]
    public string message{get;set;}
}

}