# Beautiful Fundamental
A abstract foundation for C# server (console) and client applications. 

## Getting started
Explaining how to use on client and server side.

### Use for client applications
**_General Hint:_** Under bin/Dlls you can find the dlls to include to your project.

**How to use it for console applications:**
``` C#
internal class Program
{
	private static readonly CancellationTokenSource ClientProgramCancellationTokenSource = new();
	private static IHost? _host;

	static async Task Main(string[] args)
	{
		_host = CreateHostBuilder(args)
			.Build();

		var hostRunTask = _host.RunAsync(ClientProgramCancellationTokenSource.Token);
		await hostRunTask;
		_host.Dispose();
	}

	private static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
      // Adding fundamental core framework
			.UseBeautifulFundamentalCore()
			.ConfigureServices((_, services) =>
			{
        // --- CONFIGURATION ---
        
				var config = FundamentalApplicationBuilder.CreateAndSetupConfig(services);
			});
}
```
**How to use it for maui applications:**
```C#
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
    var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Configurations
		var config = FundamentalApplicationBuilder.CreateAndSetupConfig(builder.Services);
		builder.Configuration.AddConfiguration(config);

    // Adding the fundamental core framework
		FundamentalApplicationBuilder.RegisterBeautifulFundamentalCore(builder.Services);

		return builder.Build();
	}
}
```

### Use for server applications
```C#
internal class Programm
{
	private static readonly CancellationTokenSource ServerProgramCancellationTokenSource = new();
	private static IHost _host;

	static async Task Main(string[] args)
	{
     _host = CreateHostBuilder(args)
			.Build();
		var hostRunTask = _host.RunAsync(ServerProgramCancellationTokenSource.Token);
		await hostRunTask;
		_host.Dispose();
	}

	private static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			// Adding the fundamental core framework for servers
      .UseBeautifulFundamentalServer()
			.ConfigureServices((_, services) =>
			{
				// --- CONFIGURATION ---

				var config = FundamentalServerApplicationBuilder.CreateAndSetupConfig(services);

        // --- SPECIALIZED (EXAMPLE) ---
        // Add you your session loop, which inherts from SessionLoopBase
        services.AddScoped<ISessionLoop, YourSessionLoop>();

			});
	}

public class YourSessionLoop : SessionLoopBase
{
	public YourSessionLoop(IIdentificationKey identificationKey) : base(identificationKey)
	{
	}

	protected override void Run()
	{
		// Your logic
	}
}

```

### How to add new configurations 
```C#
services.AddSingleton<IYourSetting>(_ =>
         config.GetSection(nameof(YourSetting)).Get<YourSetting>() ??
         YourSetting.Default);
```

**_Note:_** Do not forget to add your setting to the appsettings.json file, if you add some new settings to the project.
