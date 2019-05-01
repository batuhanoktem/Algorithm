using Algorithm.Model.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model.Concrete.Sub
{
    public class User : BaseModel
    {
        [StringLength(200)]
        [Required]
        public string UserName { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        [StringLength(60)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(200)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(200)]
        public string Company { get; set; }
        public int GraduationYear { get; set; }
        [StringLength(2000)]
        public string Bio { get; set; }
        [StringLength(2000)]
        public string SocialMedia { get; set; }
        [StringLength(200)]
        public string Photo { get; set; }
        public string DefaultCode { get; set; }

        //interests ---

    }
}
