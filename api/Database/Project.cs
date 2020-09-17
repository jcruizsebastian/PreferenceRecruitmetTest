using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Database
{
    public class Project
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public ICollection<User> Users { get; set; }
    }
}