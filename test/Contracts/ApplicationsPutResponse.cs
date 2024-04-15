namespace ApplicationStore.Api.Contracts;
public record ApplicationsPutResponse(
     Guid id,
     string Activity,
     string Name,
     string Description,
     string Outline);

