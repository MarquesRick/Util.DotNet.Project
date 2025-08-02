using Microsoft.AspNetCore.HttpLogging;

using Webhook.Server.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<WebhookService>();
builder.Services.AddLogging();

builder.Services.AddW3CLogging(logging =>
{
    logging.LoggingFields = W3CLoggingFields.All;
    logging.FlushInterval = TimeSpan.FromSeconds(2);
});

var app = builder.Build();
app.UseW3CLogging(); //ativando log

app.MapPost("/subscribe", (WebhookService ws, Subscription sub) 
    => ws.Subscribe(sub));

app.MapPost("/publish", async (WebhookService ws, PublishRequest req)
    => await ws.PublishMessage(req.Topic, req.Message));

app.Run();