using DevToDevAnalytics.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevToDevAnalytics.Dto;

public class DevToDevSubscriptionRenewalDto
{
    public string CustomId { get; set; } = null!;

    [JsonConverter(typeof(StringEnumConverter))]
    public NotificationTypes NotificationType { get; set; }
    public int? OriginalTransactionId { get; set; }
    public int TransactionId { get; set; }
    public long StartDateMs { get; set; }
    public long ExpiresDateMs { get; set; }
    public string Product { get; set; } = null!;
    public bool IsTrial { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = null!;
}