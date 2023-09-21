namespace DMD.Domain.Models
{
    public class Album : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public IDictionary<string, Song> Songs { get; set; } = new Dictionary<string, Song>();
    }
}