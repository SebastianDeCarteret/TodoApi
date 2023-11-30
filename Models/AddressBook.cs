namespace TodoApi.Models
{
    public class AddressBook
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Postcode { get; set; }
    }
}
