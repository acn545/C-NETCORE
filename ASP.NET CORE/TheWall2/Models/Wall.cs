using System;
using System.ComponentModel.DataAnnotations;
namespace TheWall2.Models
{
    public class BaseEntity{

    }
    public class RegisterUser: BaseEntity{
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
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string password{get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords do not match please try again")]
        public string confirm_password{get;set;}
    }
    public class LoginUser: BaseEntity{
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }

    public class CreateMessage: BaseEntity{
        [Required]
        [MinLength(10)]
        public string message{get;set;}

    }
    public class CreateComment: BaseEntity{
        [Required]
        [MinLength(10)]
        public string comment{get;set;}

        public int message_id{get;set;}
    }
}