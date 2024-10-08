using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCatalogue.Models;

public class Channel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
    public ICollection<Video> Videos { get; set; }
}