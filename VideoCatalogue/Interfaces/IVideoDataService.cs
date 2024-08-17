using VideoCatalogue.Models;
using YoutubeDLSharp.Metadata;

namespace VideoCatalogue.Interfaces;

public interface IVideoDataService
{
    public Task<Video?> GetVideoAsync(Guid id, CancellationToken cancellationToken);
    public Task<IEnumerable<Video>> GetVideosAsync(CancellationToken cancellationToken);
    public Task<IEnumerable<Video>> GetVideosByChannelAsync(Guid channelId, CancellationToken cancellationToken);
    public Task<IEnumerable<Video>> GetVideosByFilterAsync(string filter, CancellationToken cancellationToken);
    public Task<IEnumerable<Video>> GetVideosByTagsAsync(List<string> tags, CancellationToken cancellationToken);
    public Task AddVideoAsync(VideoData videoData, CancellationToken cancellationToken);
    public Task DeleteVideoAsync(Guid id, CancellationToken cancellationToken);
}