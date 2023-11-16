using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    private const string SectionName = nameof(JwtOptions);

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
