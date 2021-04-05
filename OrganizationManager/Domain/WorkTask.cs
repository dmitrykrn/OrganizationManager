
namespace OrganizationManager.Domain
{
    public class WorkTask
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string AssignDate { get; set; }
        public string DueDate { get; set; }
        public long OwnerId { get; set; }
    }
}
