using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCatalogue.Models;

public class Video
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Thumbnail { get; set; }
    public required string VideoUrl { get; set; }
    public float? Runtime { get; set; }
    public DateTime? UploadDate { get; set; }
    [ForeignKey("Channel")]
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; }
    
    public ICollection<Tag> Tags { get; set; }
}