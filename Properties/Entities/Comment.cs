public class Comment : BaseEntity
{
    public Design Design { get; set; }
    public User User { get; set; }
    public string CommentContent { get; set; }
    public DateTime DateComment { get; set; }
}