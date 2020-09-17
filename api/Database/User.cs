using System.ComponentModel.DataAnnotations;

namespace Api.Database
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}