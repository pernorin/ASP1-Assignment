namespace ASP1_Assignment.Models.Entities
{
    public class UserProfileEntity // heter IdentityUserProfile i videon  Ska den ärva från IdentityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //public string Id { get; set; } = Guid.NewGuid().ToString();  // funkar det?
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;  // bort?
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Password { get; set; } = null!;  // bort?
        public string? PhoneNumber { get; set; }  // bort?
        public string? Company { get; set; }


        // Gör required osv

    }
}
