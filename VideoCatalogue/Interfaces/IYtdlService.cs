using VideoCatalogue.Models;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;

namespace VideoCatalogue.Interfaces;

public interface IYtdlService
{
    public Task<RunResult<string>> BeginVideoDownloadAsync(string url, CancellationToken cancellationToken);
    public Task<VideoData> GetVideoDataAsync(string url, CancellationToken cancellationToken);
}