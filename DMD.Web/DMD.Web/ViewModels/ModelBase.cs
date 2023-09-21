namespace DMD.Web.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifiedOn { get; set; }
        public string CreatedBy { get; init; } = "System";
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
