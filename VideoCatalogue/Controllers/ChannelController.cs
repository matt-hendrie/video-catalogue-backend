using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using VideoCatalogue.Models;
using VideoCatalogue.Services;

namespace VideoCatalogue.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class ChannelController(ChannelDataService channelDataService): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetChannel(Guid id, CancellationToken cancellationToken)
    {
        var res = await channelDataService.GetChannelAsync(id, cancellationToken);
        return Ok(res);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetChannels(CancellationToken cancellationToken)
    {
        var res = await channelDataService.GetChannelsAsync(cancellationToken);
        return Ok(res);
    }
    
    [HttpGet("url/{url}")]
    public async Task<IActionResult> GetChannelByUrl(string url, CancellationToken cancellationToken)
    {
        var res = await channelDataService.GetChannelByUrlAsync(url, cancellationToken);
        return Ok(res);
    }
    
    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetChannelsByName(string name, CancellationToken cancellationToken)
    {
        var res = await channelDataService.GetChannelsByNameAsync(name, cancellationToken);
        return Ok(res);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddChannel(Channel channel, CancellationToken cancellationToken)
    {
        await channelDataService.AddChannelAsync(channel, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChannel(Guid id, CancellationToken cancellationToken)
    {
        await channelDataService.DeleteChannelAsync(id, cancellationToken);
        return Ok();
    }
}