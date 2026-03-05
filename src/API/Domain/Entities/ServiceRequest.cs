namespace EnterpriseServiceRequest.API.Domain.Entities;

public class ServiceRequest : BaseEntity
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";

    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; }
}