public class ApiItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Modified { get; set; }
    public DateTime Created { get; set; }
    public string? OData__TopicHeader { get; set; }
    public List<Topics> Service_x0020_omr_x00e5_de { get; set; } = new List<Topics>();

}

public class Topics
{
    public string Label { get; set; } = string.Empty;
    public string TermGuid { get; set; } = string.Empty;
    public int WssId { get; set; }
}