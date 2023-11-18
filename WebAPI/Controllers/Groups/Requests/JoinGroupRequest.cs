namespace WebAPI;

public class JoinGroupRequest
{
    public Guid Group { get; set; }
    
    public Guid Member { get; set; }
}
