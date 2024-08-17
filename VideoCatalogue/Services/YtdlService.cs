using VideoCatalogue.Interfaces;

namespace VideoCatalogue.Services;

public class YtdlService: IYtdlService
{
    public Task<MemoryStream> DownloadVideoAsync(string url, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}