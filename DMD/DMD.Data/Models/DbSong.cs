namespace DMD.Data.Models
{
    public class DbSong : DbModelBase
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan Length { get; set; }
        public Guid DbAlbumId { get; set; }
    }
}