
namespace OrganizationManager.Domain
{
    public class Report
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public long OwnerId { get; set; }
    }
}
