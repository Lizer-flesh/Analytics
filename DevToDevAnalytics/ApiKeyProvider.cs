using DevToDevAnalytics.Options;
using Microsoft.Extensions.Options;

namespace DevToDevAnalytics;

public class ApiKeyProvider
{
    private readonly Dictionary<string, string> _apiKeyByPlatformDictionary;

    public ApiKeyProvider(IOptions<List<ApiKeyOptions>> apikeysDictionary)
    {
        _apiKeyByPlatformDictionary = apikeysDictionary.Value.ToDictionary(x => x.Platform, x => x.ApiKey);
    }
    
    public bool GetApiKeyByPlatform(string platform, out string? apiKey)
    {
        return _apiKeyByPlatformDictionary.TryGetValue(platform, out apiKey);
    }
}