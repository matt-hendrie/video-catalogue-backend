using VideoCatalogue.Interfaces;
using VideoCatalogue.Models;
using VideoCatalogue.Repositories;
using YoutubeDLSharp.Metadata;

namespace VideoCatalogue.Services;

public class VideoDataService(VideoDataRepository dataRepository): IVideoDataService
{
    public async Task<Video?> GetVideoAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dataRepository.GetVideoAsync(id);
    }

    public async Task<IEnumerable<Video>> GetVideosAsync(CancellationToken cancellationToken)
    {
        return await dataRepository.GetVideosAsync();
    }

    public async Task<IEnumerable<Video>> GetVideosByChannelAsync(Guid channelId, CancellationToken cancellationToken)
    {
        return await dataRepository.GetVideosByChannelAsync(channelId);
    }

    public async Task<IEnumerable<Video>> GetVideosByFilterAsync(string filter, CancellationToken cancellationToken)
    {
        return await dataRepository.GetVideosByFilterAsync(filter);
    }

    public async Task<IEnumerable<Video>> GetVideosByTagsAsync(List<string> tags, CancellationToken cancellationToken)
    {
        return await dataRepository.GetVideosByTagsAsync(tags);
    }

    public Task AddVideoAsync(VideoData videoData, CancellationToken cancellationToken)
    {
        return dataRepository.AddVideoDataAsync(videoData);
    }

    public Task DeleteVideoAsync(Guid id, CancellationToken cancellationToken)
    {
        return dataRepository.DeleteVideoAsync(id);
    }
}