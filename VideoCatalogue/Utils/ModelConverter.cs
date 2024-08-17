using VideoCatalogue.Models;
using YoutubeDLSharp.Metadata;
using Microsoft.EntityFrameworkCore;
using VideoCatalogue.EfCore;

namespace VideoCatalogue.Utils;

public class ModelConverter(VideoDbContext dbContext)
{
    public async Task<Video> ConvertToVideo(VideoData videoData, VideoDbContext dbContext)
    {
        var existingChannel = await dbContext.Set<Channel>()
            .FirstOrDefaultAsync(c => c.Url == videoData.ChannelUrl);

        var channel = existingChannel ?? new Channel
        {
            Name = videoData.Uploader,
            Url = videoData.ChannelUrl
        };

        var tags = new List<Tag>();
        foreach (var tagName in videoData.Tags)
        {
            var existingTag = await dbContext.Set<Tag>()
                .FirstOrDefaultAsync(t => t.Name == tagName);

            var tag = existingTag ?? new Tag
            {
                Name = tagName
            };

            tags.Add(tag);
        }

        return new Video
        {
            Title = videoData.Title,
            Description = videoData.Description,
            Thumbnail = videoData.Thumbnail,
            VideoUrl = videoData.Url,
            Runtime = videoData.Duration,
            UploadDate = videoData.UploadDate,
            Channel = channel,
            Tags = tags
        };
    }
}