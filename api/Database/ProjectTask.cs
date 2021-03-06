using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database
{
    public class ProjectTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public TaskSeverity Severity { get; set; }
        [Required]
        public TaskStatus Status { get; set; }

        public enum TaskSeverity
        {
            HIGH,
            MEDIUM,
            LOW
        }

        public enum TaskStatus
        {
            TODO,
            DOING,
            DONE
        }
    }
}