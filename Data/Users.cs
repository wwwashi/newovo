namespace newOvo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        public int IDUser { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Midname { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public int? GenderID { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual UsersRole UsersRole { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Surname) || !(Surname.Length >= 3 && Surname.Length <= 20))
                errors.Add(new ValidationResult("Фамилия должна быть от 3 до 20 символов."));

            if (string.IsNullOrEmpty(Name) || !(Name.Length >= 3 && Name.Length <= 15))
                errors.Add(new ValidationResult("Имя должно быть от 3 до 15 символов."));

            if (string.IsNullOrEmpty(Phone) || Phone.Length != 11)
                errors.Add(new ValidationResult("Телефон должен состоять из 11 символов"));
            //if (string.IsNullOrEmpty(Email))
            //    errors.Add(new ValidationResult("email null"));
            return errors;
        }
    }
}
