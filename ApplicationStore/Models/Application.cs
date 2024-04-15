using ApplicationStore.Core.Validators;

namespace ApplicationStore.Core.Models;

sealed public class Application
{
    public const int MaxNameLength = 100;
    public const int MaxDescriptionLength = 300;
    public const int MaxOutlineLength = 1000;
    private Application(Guid id, Guid authorId, string activity, string name, string description, string outline, DateTime submitted)
    {
        this.id = id;
        this.author = authorId;
        this.activity = activity;
        this.name = name;
        this.description = description;
        this.outline = outline;
        this.submitted = submitted;
    }
    public Guid id { get; }
    public Guid author { get; }
    public string activity { get; } = string.Empty;
    public string name { get; } = string.Empty;
    public string description { get; } = string.Empty;
    public string outline { get; } = string.Empty;
    public DateTime submitted { get; set; } = DateTime.MinValue;

    public static (Application Application, string Error) Create(Guid Id, Guid author, string activity, string name, string description, string outline, DateTime submitted)
    {
        var error = ValidatorApp.ValidatorContractBase(Id, author, activity, name, description, outline, submitted);
        var Application = new Application(Id, author, activity, name, description, outline, submitted);
        return (Application, error);
    }

}

