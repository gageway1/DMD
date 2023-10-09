namespace DMD.Data.Models
{
    public class DbAlbum : DbModelBase
    {
        public string Name { get; set; } = string.Empty;
        public IList<DbSong> Songs { get; set; } = new List<DbSong>();
    }
}