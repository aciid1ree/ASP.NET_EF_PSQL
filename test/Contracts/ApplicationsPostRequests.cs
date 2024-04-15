namespace ApplicationStore.Api.Contracts;
public record ApplicationsPostRequests (
    Guid author,
    string activity,
    string name,  
    string description, 
    string outline);
