namespace EmailMarketingApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Tags { get; set; }

        public ContactStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum ContactStatus
    {
        Active = 1,
        Unsubscribed = 2
    }

}
