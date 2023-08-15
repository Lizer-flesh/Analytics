using System.Text.Json.Serialization;
using DevToDevAnalytics.Enums;
using Newtonsoft.Json.Converters;

namespace DevToDevAnalytics.Dto;

public class DevToDevSubscriptionCancellationDto
{
    public string CustomId { get; set; } = null!;

    [JsonConverter(typeof(StringEnumConverter))]
    public NotificationTypes NotificationType { get; set; }
    public int? OriginalTransactionId { get; set; }
    public int TransactionId { get; set; }
    public long ExpiresDateMs { get; set; }
    public string Product { get; set; } = null!;
    public bool IsTrial { get; set; }
}