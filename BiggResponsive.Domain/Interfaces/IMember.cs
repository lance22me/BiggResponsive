


namespace BiggResponsive.Domain.Interfaces
{
    public interface IMember
    {
        int PersonId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
    }
}
