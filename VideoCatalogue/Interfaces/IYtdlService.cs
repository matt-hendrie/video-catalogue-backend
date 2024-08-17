using YoutubeDLSharp;

namespace VideoCatalogue.Interfaces;

public interface IYtdlService
{
    public Task<RunResult<string>> BeginVideoDownloadAsync(string url, CancellationToken cancellationToken);
}