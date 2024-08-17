namespace VideoCatalogue.Interfaces;

public interface IYtdlService
{
    public Task<MemoryStream> DownloadVideoAsync(string url, CancellationToken cancellationToken);
}