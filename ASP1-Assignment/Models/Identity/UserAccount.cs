namespace ASP1_Assignment.Models.Identity
{
    public class UserAccount // För att listas upp på profilsidan
    {
        
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
    }
}
