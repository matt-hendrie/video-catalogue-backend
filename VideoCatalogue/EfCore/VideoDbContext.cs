using Microsoft.EntityFrameworkCore;
using VideoCatalogue.Models;

namespace VideoCatalogue.EfCore;

public class VideoDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Video> VideoData { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public VideoDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>().HasOne(v => v.Channel).WithMany(c => c.Videos);
    }
}