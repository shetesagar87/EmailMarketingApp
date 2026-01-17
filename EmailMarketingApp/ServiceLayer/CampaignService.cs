namespace EmailMarketingApp.ServiceLayer
{
    public class CampaignService : ICampaignService
    {
        private readonly IEmailSender _emailSender;

        public CampaignService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task ScheduleCampaignAsync(int campaignId)
        {
            BackgroundJob.Enqueue(() => _emailSender.SendCampaignEmails(campaignId));
        }
    }

}
