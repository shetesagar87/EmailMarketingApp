using System;
using System.ComponentModel.DataAnnotations;

namespace EmailMarketingApp.Models
{
    public class Campaign
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ScheduledDate { get; set; }

        public CampaignStatus Status { get; set; }
    }

    public enum CampaignStatus
    {
        Draft,
        Scheduled,
        Sent,
        Failed
    }
}