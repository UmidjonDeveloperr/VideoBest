using Microsoft.Net.Http.Headers;
using VideoBest.Brokers.Storages;
using VideoBest.Services.Foundations.VideoMetadatas;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<StorageBroker>();
        builder.Services.AddTransient<IStorageBroker, StorageBroker>();
        builder.Services.AddTransient<IVideoMetadataService, VideoMetadataService>();

        // Configure CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowVideoBest.Web",
                builder =>
                {
                    builder.WithOrigins("https://localhost:44365/")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Use CORS
        app.UseCors("AllowVideoBest.Web");

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
