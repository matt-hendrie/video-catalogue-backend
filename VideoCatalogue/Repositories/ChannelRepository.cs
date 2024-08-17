using Microsoft.EntityFrameworkCore;
using VideoCatalogue.EfCore;
using VideoCatalogue.Models;

namespace VideoCatalogue.Repositories;

public class ChannelRepository(VideoDbContext dbContext)
{
    public async Task AddChannelAsync(Channel channel)
    {
        await dbContext.Set<Channel>().AddAsync(channel);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Channel>> GetChannelsAsync()
    {
        return await dbContext.Set<Channel>().ToListAsync();
    }
    
    public async Task<Channel?> GetChannelAsync(Guid id)
    {
        return await dbContext.Set<Channel>().FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<Channel?> GetChannelByUrlAsync(string url)
    {
        return await dbContext.Set<Channel>().FirstOrDefaultAsync(c => c.Url == url);
    }
    
    public async Task<IEnumerable<Channel>> GetChannelsByNameAsync(string name)
    {
        return await dbContext.Set<Channel>().Where(c => c.Name.Contains(name)).ToListAsync();
    }
    
    public async Task DeleteChannelAsync(Guid id)
    {
        var channel = await dbContext.Set<Channel>().FirstOrDefaultAsync(c => c.Id == id);
        if (channel != null)
        {
            dbContext.Set<Channel>().Remove(channel);
            await dbContext.SaveChangesAsync();
        }
    }
}