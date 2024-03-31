namespace test.Contracts
{
    public record ApplicationsRequests (
        Guid author,
        string activity,
        string name,  
        string description, 
        string outline);
}
