namespace DMD.Web.Models
{
    public class Album : WebModelBase
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        public Guid DbBandId { get; set; }
    }
}