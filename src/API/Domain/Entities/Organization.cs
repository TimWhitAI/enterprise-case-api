namespace EnterpriseServiceRequest.API.Domain.Entities;

public class Organization : BaseEntity
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
}