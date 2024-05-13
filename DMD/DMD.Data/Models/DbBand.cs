using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DMD.Data.Models
{
    public class DbBand : DbModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public ICollection<DbAlbum> Albums { get; set; } = new List<DbAlbum>();
        public ICollection<DbBandMember> Members { get; set;} = new List<DbBandMember>();
    }
}