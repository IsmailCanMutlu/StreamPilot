using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;


namespace StreamPilot.Data.Context;

public class StreamPilotDbContextFactory : IDesignTimeDbContextFactory<StreamPilotDbContext>
{
    public StreamPilotDbContext CreateDbContext(string[] args)
    {
        var projectPath = "/Users/ismailcanmutlu/RiderProjects/StreamPilot/StreamPilot.Api";

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<StreamPilotDbContext>();
        var connectionString = configuration.GetConnectionString("StreamPilotDatabase");

        builder.UseNpgsql(connectionString);

        return new StreamPilotDbContext(builder.Options);
    }
}



