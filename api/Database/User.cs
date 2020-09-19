using api.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Database
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Elevated { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
    }
}