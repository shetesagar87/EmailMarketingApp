namespace EmailMarketingApp.Models
{
    using System;

    public class CampaignEmail
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public DateTime? SentAt { get; set; }

        public DateTime? OpenedAt { get; set; }

        public DateTime? ClickedAt { get; set; }

        public bool IsBounced { get; set; }

        public bool IsUnsubscribed { get; set; }
    }

}
