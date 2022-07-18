public class Design : BaseEntity{
    public string DesignName { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; }
    public DesignType DesignType { get; set; }
    public string? Colors { get; set; }
    public DateTime DateUploaded { get; set; }
}