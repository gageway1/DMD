using Nelibur.ObjectMapper;

namespace DMD.Web.Models
{
    public class Band : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public IDictionary<string, Album> Albums { get; set; } = new Dictionary<string, Album>();
        public IDictionary<string, BandMember> Members = new Dictionary<string, BandMember>();
    }
}