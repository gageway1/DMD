namespace DMD.Data.Models
{
    public abstract class DbModelBase
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset CreatedOn { get; init; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifiedOn { get; set; }
        public string CreatedBy { get; init; } = "System";
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
