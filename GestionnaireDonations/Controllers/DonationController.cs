using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionnaireDonation.Models;

namespace GestionnaireDonations.Controllers
{
    public class DonationController : Controller
    {
        private readonly DonationDbContext _context;

        public DonationController(DonationDbContext context)
        {
            _context = context;
        }

        // GET: Donation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donations.ToListAsync());
        }

        // GET: Donation/Details/5
        [NoDirectAccess]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donationModel = await _context.Donations
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donationModel == null)
            {
                return NotFound();
            }

            return View(donationModel);
        }


        [NoDirectAccess]
        public async Task<IActionResult> AddEdit(int id= 0)
        {
            if (id == 0)
                return View(new DonationModel()) ;
            else
            {
                var donationModel = await _context.Donations
               .FindAsync(id);
                if (donationModel == null)
                {
                    return NotFound();
                }

                return View(donationModel);
            }
        }

        

       
        // POST: Donation/AddEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(int id, [Bind("DonationId,DonationCode,DonateurNom,BanqueNom,RIBCode,Montant, Date")] DonationModel donationModel)
        {
           

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    donationModel.Date = DateTime.Now;
                    _context.Add(donationModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                    _context.Update(donationModel);
                    await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DonationModelExists(donationModel.DonationId))
                        {
                        return NotFound();
                        }
                        else
                        {
                        throw;
                        }
                    }

                }

                return Json(new { isValid = true, html = Utils.RenderRazorViewToString(this, "_ViewAll",_context.Donations.ToList()) });
            }
            return Json(new { isValid = false, html = Utils.RenderRazorViewToString(this, "AddEdit", donationModel)});

        }

        
        // POST: Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donationModel = await _context.Donations.FindAsync(id);
            _context.Donations.Remove(donationModel);
            await _context.SaveChangesAsync();
            return Json(new {  html = Utils.RenderRazorViewToString(this, "_ViewAll", _context.Donations.ToList()) });

        }

        private bool DonationModelExists(int id)
        {
            return _context.Donations.Any(e => e.DonationId == id);
        }
    }
}
