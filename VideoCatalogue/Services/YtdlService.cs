using VideoCatalogue.Interfaces;
using VideoCatalogue.Models;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;

namespace VideoCatalogue.Services;

public class YtdlService(IConfiguration config, IVideoDataService videoDataService): IYtdlService
{
    public async Task<RunResult<string>> BeginVideoDownloadAsync(string url, CancellationToken cancellationToken)
    {
        var downloader = await GetDownloader();
        var data = await downloader.RunVideoDataFetch(url, ct: cancellationToken);
        var videoData = data.Data;
        await videoDataService.AddVideoAsync(videoData, cancellationToken);
        var res = await downloader.RunVideoDownload(url, ct: cancellationToken);
        return res;
    }

    public async Task<VideoData> GetVideoDataAsync(string url, CancellationToken cancellationToken)
    {
        var downloader = await GetDownloader();
        var res = await downloader.RunVideoDataFetch(url, ct: cancellationToken);
        return res.Data;
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