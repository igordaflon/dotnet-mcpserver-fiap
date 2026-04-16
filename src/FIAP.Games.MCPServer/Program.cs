using FIAP.Games.MCPServer.Clients;
using FIAP.Games.MCPServer.Prompts;
using FIAP.Games.MCPServer.Resources;
using FIAP.Games.MCPServer.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Protocol;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();

var serverInfo = new Implementation { Name = "DotnetMCPServer.Stdio", Version = "1.0.0" };
builder.Services
    .AddMcpServer(mcp =>
    {
        mcp.ServerInfo = serverInfo;
    })
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(FiapGamesTools).Assembly)
    .WithPromptsFromAssembly(typeof(FiapGamesPrompts).Assembly)
    .WithResourcesFromAssembly(typeof(FiapGamesResources).Assembly);


builder.Services.AddHttpClient<JogoApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7143/api/");
});

var app = builder.Build();
await app.RunAsync();



