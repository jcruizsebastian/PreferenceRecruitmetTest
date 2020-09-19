using Api.Database;

namespace api.Database
{
    public class ProjectUser
    {
        public Project Project { get; set; }
        public string ProjectId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
