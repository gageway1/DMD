namespace DMD.Web.Models
{
    public class Song : WebModelBase
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Length { get; set; }
        public Guid DbAlbumId { get; set; }
    }
}