namespace EmailMarketingApp.ServiceLayer
{
    public interface ICampaignService
    {
        Task ScheduleCampaignAsync(int campaignId);
    }

}