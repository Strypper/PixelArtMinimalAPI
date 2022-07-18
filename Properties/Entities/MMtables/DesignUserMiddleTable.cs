public class DesignUserMiddleTable : BaseEntity
{
    public int DesignId { get; set; }
    public virtual Design Design { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}