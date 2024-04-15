namespace ApplicationStore.DataAccess.Entities;
public class ApplicationEntity
{
    public Guid id { get; set; }
    public Guid author { get; set; }
    public string activity { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string outline { get; set; } = string.Empty;
    public DateTime submitted { get; set; } = DateTime.MinValue;
}
