namespace ApplicationStore.Api.Contracts;
public record ApplicationsFullRequests(
 Guid id,
 Guid Author,
 string Activity,
 string Name,
 string Description,
 string Outline);
