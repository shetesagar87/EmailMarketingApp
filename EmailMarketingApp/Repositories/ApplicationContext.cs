using EmailMarketingApp.Models;
using System.Collections.Generic;

namespace EmailMarketingApp.Repositories
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignEmail> CampaignEmails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }

}
