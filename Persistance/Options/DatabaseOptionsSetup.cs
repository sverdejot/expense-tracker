using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Persistance.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private const string ConfigurationSectionName = nameof(DatabaseOptions);
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        options.ConnectionString = _configuration.GetConnectionString("Database")!;

        _configuration
            .GetSection(ConfigurationSectionName)
            .Bind(options);
    }
}
