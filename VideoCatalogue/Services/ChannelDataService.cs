using VideoCatalogue.Interfaces;
using VideoCatalogue.Models;
using VideoCatalogue.Repositories;

namespace VideoCatalogue.Services;

public class ChannelDataService(ChannelRepository channelRepository): IChannelDataService
{
    public async Task<Channel?> GetChannelAsync(Guid id, CancellationToken cancellationToken)
    {
        return await channelRepository.GetChannelAsync(id);
    }

    public async Task<IEnumerable<Channel>> GetChannelsAsync(CancellationToken cancellationToken)
    {
        return await channelRepository.GetChannelsAsync();
    }

    public async Task<Channel?> GetChannelByUrlAsync(string url, CancellationToken cancellationToken)
    {
        return await channelRepository.GetChannelByUrlAsync(url);
    }

    public async Task<IEnumerable<Channel>> GetChannelsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await channelRepository.GetChannelsByNameAsync(name);
    }

    public Task AddChannelAsync(Channel channel, CancellationToken cancellationToken)
    {
        return channelRepository.AddChannelAsync(channel);
    }

    public Task DeleteChannelAsync(Guid id, CancellationToken cancellationToken)
    {
        return channelRepository.DeleteChannelAsync(id);
    }
}