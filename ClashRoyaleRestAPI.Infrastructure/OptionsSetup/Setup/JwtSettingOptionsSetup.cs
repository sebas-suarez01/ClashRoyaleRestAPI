using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClashRoyaleRestAPI.Infrastructure.OptionsSetup.Setup;

public class JwtSettingOptionsSetup : IConfigureOptions<JwtSettings>
{
    private readonly IConfiguration _configuration;

    public JwtSettingOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration.GetSection(JwtSettings.SectionName).Bind(options);
    }
}
