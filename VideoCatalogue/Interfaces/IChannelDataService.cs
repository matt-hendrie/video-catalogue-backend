using VideoCatalogue.Models;

namespace VideoCatalogue.Interfaces;

public interface IChannelDataService
{
    public Task<Channel?> GetChannelAsync(Guid id, CancellationToken cancellationToken);
    public Task<IEnumerable<Channel>> GetChannelsAsync(CancellationToken cancellationToken);
    public Task<Channel?> GetChannelByUrlAsync(string url, CancellationToken cancellationToken);
    public Task<IEnumerable<Channel>> GetChannelsByNameAsync(string name, CancellationToken cancellationToken);
    public Task AddChannelAsync(Channel channel, CancellationToken cancellationToken);
    public Task DeleteChannelAsync(Guid id, CancellationToken cancellationToken);
}