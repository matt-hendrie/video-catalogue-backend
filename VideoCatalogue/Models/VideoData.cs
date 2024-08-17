using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCatalogue.Models;

public class VideoData
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Thumbnail { get; set; }
    public required string VideoUrl { get; set; }
    public required string Runtime { get; set; }
    [ForeignKey("Channel")]
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; }
}