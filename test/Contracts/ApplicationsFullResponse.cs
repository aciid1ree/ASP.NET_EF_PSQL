namespace ApplicationStore.Api.Contracts;
public record ApplicationsFullResponse (
   Guid Id,
   string Activity,
   string Name, 
   string Description, 
   string Outline);
