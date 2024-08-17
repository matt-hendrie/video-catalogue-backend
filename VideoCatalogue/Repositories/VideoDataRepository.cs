using Microsoft.EntityFrameworkCore;
using VideoCatalogue.EfCore;
using VideoCatalogue.Models;
using VideoCatalogue.Utils;
using YoutubeDLSharp.Metadata;

namespace VideoCatalogue.Repositories;

public class VideoDataRepository(VideoDbContext dbContext)
{
    public async Task AddVideoDataAsync(VideoData video)
    {
        var videoModel = await ModelConverter.ConvertToVideo(video, dbContext);
        await dbContext.Set<Video>().AddAsync(videoModel);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Video>> GetVideosAsync()
    {
        return await dbContext.Set<Video>().ToListAsync();
    }
    
    public async Task<Video?> GetVideoAsync(Guid id)
    {
        return await dbContext.Set<Video>().FirstOrDefaultAsync(v => v.Id == id);
    }
    
    public async Task<IEnumerable<Video>> GetVideosByChannelAsync(Guid channelId)
    {
        return await dbContext.Set<Video>().Where(v => v.ChannelId == channelId).ToListAsync();
    }
    
    public async Task<IEnumerable<Video>> GetVideosByFilterAsync(string filter)
    {
        return await dbContext.Set<Video>().Where(v => v.Title.Contains(filter) || v.Description.Contains(filter)).ToListAsync();
    }
    
    public async Task<IEnumerable<Video>> GetVideosByTagsAsync(List<string> tags)
    {
        return await dbContext.Set<Video>().Where(v => v.Tags.Any(t => tags.Contains(t.Name))).ToListAsync();
    }
    
    public async Task DeleteVideoAsync(Guid id)
    {
        var video = await dbContext.Set<Video>().FirstOrDefaultAsync(v => v.Id == id);
        if (video != null)
        {
            dbContext.Set<Video>().Remove(video);
            await dbContext.SaveChangesAsync();
        }
    }
}