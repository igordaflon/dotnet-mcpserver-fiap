using FIAP.Games.MCPServer.Clients;
using FIAP.Games.MCPServer.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Debug;
});

builder.Configuration.AddEnvironmentVariables();

var serverInfo = new Implementation { Name = "DotnetMCPServer.Stdio", Version = "1.0.0" };
builder.Services
    .AddMcpServer(mcp =>
    {
        mcp.ServerInfo = serverInfo;
    })
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(FiapGamesTools).Assembly);


builder.Services.AddHttpClient<JogoApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7143/api/");
});

var app = builder.Build();
await app.RunAsync();
