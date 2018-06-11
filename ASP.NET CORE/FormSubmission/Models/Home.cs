using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models{
    public class User{
        [Required]
        [MinLength(2)]
        public string first_name{get;set;}
        [Required]
        [MinLength(2)]
        public string last_name{get;set;}
        [Required]
        [MinLength(1)]
        public string Age {get;set;}
        [Required]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password{get;set;}
    }

    public abstract class BaseEntity{}
}