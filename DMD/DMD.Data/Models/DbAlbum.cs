namespace DMD.Data.Models
{
    public class DbAlbum : DbModelBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<DbSong> Songs { get; set; } = new List<DbSong>();
        public Guid DbBandId { get; set; }
    }
}