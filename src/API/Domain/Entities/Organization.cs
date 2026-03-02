public class Organization : BaseEntity
{
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<ServiceRequest> ServiceRequests { get; set; }
}
