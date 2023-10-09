namespace DMD.Data.Models
{
    public class DbBand : DbModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public IList<DbAlbum> Albums { get; set; } = new List<DbAlbum>();
        public IList<DbBandMember> Members = new List<DbBandMember>();
    }
}