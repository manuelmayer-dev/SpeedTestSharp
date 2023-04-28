# SpeedTestSharp
A simple and lightweight library to test the latency, download and upload speed of the internet.

## NuGet
https://www.nuget.org/packages/SuchByte.SpeedTestSharp/

## Basic Usage
```c#
ISpeedTestClient speedTestClient = new SpeedTestClient();
var result = await speedTestClient.TestSpeedAsync(SpeedUnit.Mbps);
Console.WriteLine($"Latency: {result.Latency}ms");
Console.WriteLine($"Download: {result.DownloadSpeed} {result.SpeedUnit}");
Console.WriteLine($"Upload: {result.UploadSpeed} {result.SpeedUnit}");
````

## Usage with events
```c#
ISpeedTestClient speedTestClient = new SpeedTestClient();

speedTestClient.StageChanged += (sender, stage) =>
{
    Console.WriteLine($"Changed stage to: {stage}");
};

speedTestClient.ProgressChanged += (sender, info) =>
{
    switch (speedTestClient.CurrentStage)
    {
        case TestStage.Download:
            Console.Write("Downloaded ");
            break;
        case TestStage.Upload:
            Console.Write("Uploaded ");
            break;
    }
    Console.WriteLine($"{info.BytesProcessed} bytes @ {info.Speed} {speedTestClient.SpeedUnit}");
};

var result = await speedTestClient.TestSpeedAsync(SpeedUnit.Mbps);

Console.WriteLine($"Latency: {result.Latency}ms");
Console.WriteLine($"Download: {result.DownloadSpeed} {result.SpeedUnit}");
Console.WriteLine($"Upload: {result.UploadSpeed} {result.SpeedUnit}");
```

## SpeedUnit
- Kbps -> KiloBitsPerSecond
- KBps -> KiloBytesPerSecond
- Mbps -> MegaBitsPerSecond
- MBps -> MegaBytesPerSecond

## ISpeedTestClient
```c#
public TestStage CurrentStage { get; }
public SpeedUnit SpeedUnit { get; }
public event EventHandler<TestStage>? StageChanged;
public event EventHandler<ProgressInfo>? ProgressChanged;
public Task<SpeedTestResult> TestSpeedAsync(SpeedUnit speedUnit, int parallelTasks = 8, bool testLatency = true, bool testDownload = true, bool testUpload = true);
```

## Used servers
This library uses the servers of https://speedtest.net
