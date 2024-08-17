using System.Web;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using VideoCatalogue.Interfaces;

namespace VideoCatalogue.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class YtdlController(IYtdlService ytdlService): ControllerBase
{
    [HttpGet("{url}")]
    public IActionResult DownloadVideo(string url, CancellationToken cancellationToken)
    {
        ytdlService.BeginVideoDownloadAsync(HttpUtility.UrlDecode(url), cancellationToken);
        return Ok();
    }
    
    [HttpGet("info/{url}")]
    public async Task<IActionResult> GetVideoInfo(string url, CancellationToken cancellationToken)
    {
        var res = await ytdlService.GetVideoDataAsync(HttpUtility.UrlDecode(url), cancellationToken);
        return Ok(res);
    }
}