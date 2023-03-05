namespace IdentityServer.Server.Entities
{
    public class Photo
    {
        public int Id { get; set; }
		public int PhotoId { get; set; }
		public string PhotoUrl { get; set; } = String.Empty;
        public string PhotoName { get; set; } = String.Empty;
    }
}
