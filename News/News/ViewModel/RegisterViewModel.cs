using System;
using System.ComponentModel.DataAnnotations;

namespace News.ViewModel
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, MinLength(4)]
        public string UserName { get; set; }
        [Required, MinLength(4), DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}