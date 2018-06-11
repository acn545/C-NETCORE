using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models{
    public abstract class BaseEntity {}

    public class User:BaseEntity{
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]*$")]
        public string first_name{get;set;}

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]*$")]
        public string last_name{get;set;}
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password{get;set;}

    }

    public class LoginUser:BaseEntity{
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [MinLength(2)]
        public string password{get;set;}
    }
}