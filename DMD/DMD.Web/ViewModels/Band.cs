using Nelibur.ObjectMapper;

namespace DMD.Web.Models
{
    public class Band : WebModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<BandMember> BandMembers { get; set; } = new List<BandMember>();
    }
}