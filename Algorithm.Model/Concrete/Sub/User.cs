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
        public string Name { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [StringLength(200)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(200)]
        public string Company { get; set; }
        public int GraditonYear { get; set; }
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
