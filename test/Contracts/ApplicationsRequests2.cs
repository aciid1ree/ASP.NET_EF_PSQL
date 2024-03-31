namespace test.Contracts
{
    public record ApplicationsRequests2(
     Guid id,
     Guid Author,
     string Activity,
     string Name,
     string Description,
     string Outline);
}
