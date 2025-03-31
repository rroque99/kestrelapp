using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel with HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    var certPath = "/tmp/certs/tls.crt";
    var keyPath = "/tmp/certs/tls.key";

    if (File.Exists(certPath) && File.Exists(keyPath))
    {
        var certificate = X509Certificate2.CreateFromPemFile(certPath, keyPath);
        options.ListenAnyIP(443, listenOptions =>
        {
            listenOptions.UseHttps(certificate);
        });
    }
});

var app = builder.Build();
app.MapGet("/", () => "Hello from .NET Core Kestrel over HTTPS!");

app.Run();
