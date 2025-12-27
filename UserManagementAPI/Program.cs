var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://example.com";
        options.Audience = "api";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<LoggingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();


app.Run();

