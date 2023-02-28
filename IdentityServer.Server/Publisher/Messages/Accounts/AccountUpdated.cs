namespace Events
{
    public class AccountUpdated
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public string Url { get; set; } = String.Empty;
    }
}
