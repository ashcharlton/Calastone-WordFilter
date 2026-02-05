using Calastone_WordFilter_Main;
using Calastone_WordFilter_Main.Filters.Implementations;
using Calastone_WordFilter_Main.Filters.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create the host to manage services
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<ITextFilter>(new TextContainsLetterFilter('t', ignoreCase: true));

        services.AddSingleton<ITextFilter>(new TextLengthFilter(3));

        services.AddSingleton<ITextFilter>(new MiddleVowelFilter(true));

        // 4. Register the main application logic
        services.AddSingleton<TextFilterApp>();
    })
    .Build();

// Run the application
var app = host.Services.GetRequiredService<TextFilterApp>();
await app.RunAsync(args[0]);