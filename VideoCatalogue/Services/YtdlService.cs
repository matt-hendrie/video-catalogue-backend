using VideoCatalogue.Interfaces;
using YoutubeDLSharp;

namespace VideoCatalogue.Services;

public class YtdlService(IConfiguration config): IYtdlService
{
    public async Task<RunResult<string>> BeginVideoDownloadAsync(string url, CancellationToken cancellationToken)
    {
        var downloader = await GetDownloader();
        var res = await downloader.RunVideoDownload(url, ct: cancellationToken);
        return res;
    }
    
    private async Task<YoutubeDL> GetDownloader()
    {
        var ytdl = new YoutubeDL();
        if (!File.Exists(config["Ytdl:BinaryPath"] + "/yt-dlp.exe"))
        {
            await YoutubeDLSharp.Utils.DownloadYtDlp(config["Ytdl:BinaryPath"]);
        }
        if (!File.Exists(config["Ytdl:BinaryPath"] + "/ffmpeg.exe"))
        {
            await YoutubeDLSharp.Utils.DownloadFFmpeg(config["Ytdl:BinaryPath"]);
        }
        ytdl.YoutubeDLPath = config["Ytdl:BinaryPath"] + "/yt-dlp.exe";
        ytdl.FFmpegPath = config["Ytdl:BinaryPath"] + "/ffmpeg.exe";
        ytdl.OutputFolder = config["Ytdl:OutputFolder"];
        return ytdl;
    }
}