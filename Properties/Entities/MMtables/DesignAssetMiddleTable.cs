public class DesignAssetMiddleTable : BaseEntity
{
    public int DesignId { get; set; }
    public virtual Design Design { get; set; }
    public int AssetId { get; set; }
    public virtual Asset Asset { get; set; }
    public int Order { get; set; }
}