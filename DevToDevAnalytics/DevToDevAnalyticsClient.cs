using System.Text;
using System.Web;
using DevToDevAnalytics.Dto;
using DevToDevAnalytics.Exceptions;
using DevToDevAnalytics.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DevToDevAnalytics;

public class DevToDevAnalyticsClient : IDevToDevClientAnalytics
{
    private readonly DevToDevClientAnalyticsOptions _devToDevClientAnalyticsOptions;
    private readonly HttpClient _client;
    private readonly ApiKeyProvider _apiKeyProvider;
    
    public DevToDevAnalyticsClient(HttpClient client,
        IOptions<DevToDevClientAnalyticsOptions> devToDevClientOptions,
        ApiKeyProvider apikeyProvider)
    {
        _devToDevClientAnalyticsOptions = devToDevClientOptions.Value;
        _client = client;
        _apiKeyProvider = apikeyProvider;
    }
    
    private Uri BuildUriDevToDevAnalytics(string platform)
    {
        var queryParams = HttpUtility.ParseQueryString(string.Empty);
        var apiKeyExist = _apiKeyProvider.GetApiKeyByPlatform(platform, out var apiKey);
        if (!apiKeyExist)
        {
            throw new ArgumentException($"API key for {platform} is missing");
        }
        var uriBuilder = new UriBuilder
        {
            Scheme = Uri.UriSchemeHttps,
            Host = _devToDevClientAnalyticsOptions.Host,
            Path = _devToDevClientAnalyticsOptions.Path
        };
        queryParams["apikey"] = apiKey;
        uriBuilder.Query = queryParams.ToString();

        return uriBuilder.Uri;
    }
    
    public async Task SendSubscriptionPurchaseNotificationAsync(DevToDevSubscriptionPurchaseDto devToDevSubscriptionPurchaseDto, string platform)
    {
        var uriBuilder = BuildUriDevToDevAnalytics(platform);
        var camelSettings = new JsonSerializerSettings { Converters = { new StringEnumConverter() }, ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var jsonContent = JsonConvert.SerializeObject(devToDevSubscriptionPurchaseDto, camelSettings);
        var response = await _client.PostAsync(uriBuilder, new StringContent(jsonContent, Encoding.Default, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new DevToDevApiAnalyticsException($"DevToDev API returned error code {response.StatusCode}. Request URL: {uriBuilder.AbsoluteUri}. Request body: {JsonConvert.SerializeObject(devToDevSubscriptionPurchaseDto)}. Response body: {responseContent}");
        }
    } 
    
    public async Task SendSubscriptionCancellationNotificationAsync(DevToDevSubscriptionCancellationDto devToDevSubscriptionCancellationDto, string platform)
    {
        var uriBuilder = BuildUriDevToDevAnalytics(platform);
        var camelSettings = new JsonSerializerSettings { Converters = { new StringEnumConverter() }, ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var jsonContent = JsonConvert.SerializeObject(devToDevSubscriptionCancellationDto, camelSettings);
        var response = await _client.PostAsync(uriBuilder, new StringContent(jsonContent, Encoding.Default, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new DevToDevApiAnalyticsException($"DevToDev API returned error code {response.StatusCode}. Request URL: {uriBuilder.AbsoluteUri}. Request body: {JsonConvert.SerializeObject(devToDevSubscriptionCancellationDto)}. Response body: {responseContent}");
        }
    }
    
    public async Task SendSubscriptionRenewalNotificationAsync(DevToDevSubscriptionRenewalDto devToDevSubscriptionRenewalDto, string platform)
    {
        var uriBuilder = BuildUriDevToDevAnalytics(platform);
        var camelSettings = new JsonSerializerSettings { Converters = { new StringEnumConverter() }, ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var jsonContent = JsonConvert.SerializeObject(devToDevSubscriptionRenewalDto, camelSettings);
        var response = await _client.PostAsync(uriBuilder, new StringContent(jsonContent, Encoding.Default, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new DevToDevApiAnalyticsException($"DevToDev API returned error code {response.StatusCode}. Request URL: {uriBuilder.AbsoluteUri}. Request body: {JsonConvert.SerializeObject(devToDevSubscriptionRenewalDto)}. Response body: {responseContent}");
        }
    }
    
    public async Task SendSubscriptionRefundNotificationAsync(DevToDevSubscriptionRefundDto devToDevSubscriptionRefundDto, string platform)
    {
        var uriBuilder = BuildUriDevToDevAnalytics(platform);
        var camelSettings = new JsonSerializerSettings { Converters = { new StringEnumConverter() }, ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var jsonContent = JsonConvert.SerializeObject(devToDevSubscriptionRefundDto, camelSettings);
        var response = await _client.PostAsync(uriBuilder, new StringContent(jsonContent, Encoding.Default, "application/json"));
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new DevToDevApiAnalyticsException($"DevToDev API returned error code {response.StatusCode}. Request URL: {uriBuilder.AbsoluteUri}. Request body: {JsonConvert.SerializeObject(devToDevSubscriptionRefundDto)}. Response body: {responseContent}");
        }
    }
}