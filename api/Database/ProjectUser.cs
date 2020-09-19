using Api.Database;

namespace api.Database
{
    public class ProjectUser
    {
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
