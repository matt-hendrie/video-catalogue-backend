using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using VideoCatalogue.Services;
using YoutubeDLSharp.Metadata;

namespace VideoCatalogue.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class VideoController(VideoDataService videoDataService): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVideo(Guid id, CancellationToken cancellationToken)
    {
        var res = await videoDataService.GetVideoAsync(id, cancellationToken);
        return Ok(res);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetVideos(CancellationToken cancellationToken)
    {
        var res = await videoDataService.GetVideosAsync(cancellationToken);
        return Ok(res);
    }
    
    [HttpGet("channel/{channelId}")]
    public async Task<IActionResult> GetVideosByChannel(Guid channelId, CancellationToken cancellationToken)
    {
        var res = await videoDataService.GetVideosByChannelAsync(channelId, cancellationToken);
        return Ok(res);
    }
    
    [HttpGet("filter/{filter}")]
    public async Task<IActionResult> GetVideosByFilter(string filter, CancellationToken cancellationToken)
    {
        var res = await videoDataService.GetVideosByFilterAsync(filter, cancellationToken);
        return Ok(res);
    }
    
    [HttpGet("tags/{tags}")]
    public async Task<IActionResult> GetVideosByTags(List<string> tags, CancellationToken cancellationToken)
    {
        var res = await videoDataService.GetVideosByTagsAsync(tags, cancellationToken);
        return Ok(res);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddVideo(VideoData videoData, CancellationToken cancellationToken)
    {
        await videoDataService.AddVideoAsync(videoData, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideo(Guid id, CancellationToken cancellationToken)
    {
        await videoDataService.DeleteVideoAsync(id, cancellationToken);
        return Ok();
    }
}