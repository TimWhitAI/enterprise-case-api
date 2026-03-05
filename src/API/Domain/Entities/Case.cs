using EnterpriseServiceRequest.API.Domain.Entities;
public class Case : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public int OrganizationId { get; set; }
    public int CreatedById { get; set; }
    public int AssignedToId { get; set; }

    public Organization Organization { get; set; }
    public User CreatedBy { get; set; }
    public User AssignedTo { get; set; }
}
