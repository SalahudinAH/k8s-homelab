var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var startTime = DateTime.UtcNow;

app.MapGet("/", () => Results.Ok(new
{
    app = "homelab-status-api",
    version = Environment.GetEnvironmentVariable("APP_VERSION") ?? "dev",
    pod = Environment.MachineName,
    uptimeSeconds = (int)(DateTime.UtcNow - startTime).TotalSeconds,
    timestamp = DateTime.UtcNow
}));

app.MapGet("/healthz", () => Results.Ok("healthy"));

app.Run();