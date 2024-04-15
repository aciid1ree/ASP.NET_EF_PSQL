namespace ApplicationStore.Api.Contracts;
public record ApplicationsPutResponse(
   Guid Id,
   Guid Author,
   string Activity,
   string Name,
   string Description,
   string Outline);

