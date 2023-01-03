using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRateLimiter(options => {
    options.AddFixedWindowLimiter("Api", options => {
        options.AutoReplenishment = true;
        options.PermitLimit = 2;
        options.Window = TimeSpan.FromMinutes(1);
    });
    options.AddFixedWindowLimiter("Api", options => {
        options.AutoReplenishment = true;
        options.PermitLimit = 100;
        options.Window = TimeSpan.FromHours(1);
    });
});

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
