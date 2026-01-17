namespace EmailMarketingApp.Models
{
    using System;
    using System.Collections.Generic;

    public class Campaign
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmailTemplateId { get; set; }
        public EmailTemplate EmailTemplate { get; set; }

        public DateTime? ScheduledAt { get; set; }

        public CampaignStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<CampaignEmail> CampaignEmails { get; set; }
    }

    public enum CampaignStatus
    {
        Draft = 1,
        Scheduled = 2,
        Sent = 3,
        Failed = 4
    }


}
