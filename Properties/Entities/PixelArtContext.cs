using Microsoft.EntityFrameworkCore;

public class PixelArtContext : DbContext
{
    public PixelArtContext(DbContextOptions<PixelArtContext> options) : base(options) { }
    public DbSet<User>             Users                        { get; set; }
    public DbSet<Design>           Designs                      { get; set; }
    public DbSet<DesignType>       DesignTypes                  { get; set; }
    public DbSet<Comment>          Comments                     { get; set; }
    public DbSet<DesignAssetMiddleTable> DesignAssetMiddleTable { get; set; }
    public DbSet<DesignUserMiddleTable>  DesignUserMiddleTable  { get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
        
    {
            builder.Entity<DesignAssetMiddleTable>(entity =>
            {
                entity.HasOne(e => e.Asset).WithMany().HasForeignKey(e => e.AssetId);
                entity.HasOne(e => e.Design).WithMany().HasForeignKey(e => e.DesignId);
            });

            builder.Entity<DesignUserMiddleTable>(entity =>
            {
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Design).WithMany().HasForeignKey(e => e.DesignId);
            });
    }
}