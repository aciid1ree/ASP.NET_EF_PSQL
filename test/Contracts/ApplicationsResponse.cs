namespace test.Contracts
{
    public record ApplicationsResponse (
       Guid Id,
       string Activity,
       string Name, 
       string Description, 
       string Outline);
}
