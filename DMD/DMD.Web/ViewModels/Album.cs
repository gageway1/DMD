namespace DMD.Web.Models
{
    public class Album : WebModelBase
    {
        public string Name { get; set; } = string.Empty;
        public IDictionary<string, Song> Songs { get; set; } = new Dictionary<string, Song>();
    }
}