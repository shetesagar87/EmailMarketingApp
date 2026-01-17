using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmailMarketingApp.Data;
using EmailMarketingApp.Models;
using EmailMarketingApp.Services;
namespace EmailMarketingApp.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICampaignJobService _campaignJobService;

        public CampaignsController(ApplicationDbContext context, ICampaignJobService campaignJobService)
        {
            _context = context;
            _campaignJobService = campaignJobService;
        }

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaigns.ToListAsync());
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Subject,Content,ScheduledDate")] Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                campaign.Status = CampaignStatus.Draft;
                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // POST: Campaigns/Send/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            // Prevent sending if it's not in a draft state.
            // I'm assuming the CampaignStatus enum has a 'Sending' state.
            if (campaign.Status != CampaignStatus.Draft)
            {
                TempData["ErrorMessage"] = "Campaign cannot be sent as it is not in Draft status.";
                return RedirectToAction(nameof(Index));
            }

            // The comment in the original code correctly identifies that this should be a background job.
            // The controller's responsibility should be to initiate the job, not execute it.

            // 1. Update the campaign status to "Sending" to prevent multiple sends
            campaign.Status = CampaignStatus.Sending; // Assumes a 'Sending' status exists
            _context.Update(campaign);
            await _context.SaveChangesAsync();

            // 2. Enqueue the background job to handle the actual email sending
            _campaignJobService.QueueCampaignSending(id);

            TempData["SuccessMessage"] = "The campaign has been successfully queued for sending.";
            return RedirectToAction(nameof(Index));
        }
    }
}