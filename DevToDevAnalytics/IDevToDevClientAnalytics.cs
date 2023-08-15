using DevToDevAnalytics.Dto;

namespace DevToDevAnalytics;

public interface IDevToDevClientAnalytics
{
    Task SendSubscriptionPurchaseNotificationAsync(DevToDevSubscriptionPurchaseDto devToDevSubscriptionPurchaseDto, string platform);
    Task SendSubscriptionCancellationNotificationAsync(DevToDevSubscriptionCancellationDto devToDevSubscriptionCancellationDto, string platform);
    Task SendSubscriptionRenewalNotificationAsync(DevToDevSubscriptionRenewalDto devToDevSubscriptionRenewalDto, string platform);
    Task SendSubscriptionRefundNotificationAsync(DevToDevSubscriptionRefundDto devToDevSubscriptionRefundDto, string platform);
}