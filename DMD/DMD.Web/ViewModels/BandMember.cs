namespace DMD.Web.Models
{
    public class BandMember : WebModelBase
    {
        public string Instrument { get; set; } = string.Empty;
        public Guid DbBandId { get; set; }
    }
}