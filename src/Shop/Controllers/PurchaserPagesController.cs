using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
  public class PurchaserPagesController : Controller
  {
    private readonly ApplicationDbContext _context;

    

    public PurchaserPagesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: PurchaserPages
    public async Task<IActionResult> Index()
    {
      return View(await _context.PurchaserPage.ToListAsync());
    }

    // GET: PurchaserPages/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var purchaserPage = await _context.PurchaserPage.SingleOrDefaultAsync(m => m.ID == id);
      if (purchaserPage == null)
      {
        return NotFound();
      }

      return View(purchaserPage);
    }

    // GET: PurchaserPages/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: PurchaserPages/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID")] PurchaserPage purchaserPage)
    {
      if (ModelState.IsValid)
      {
        _context.Add(purchaserPage);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(purchaserPage);
    }

    // GET: PurchaserPages/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var purchaserPage = await _context.PurchaserPage.SingleOrDefaultAsync(m => m.ID == id);
      if (purchaserPage == null)
      {
        return NotFound();
      }
      return View(purchaserPage);
    }

    // POST: PurchaserPages/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID")] PurchaserPage purchaserPage)
    {
      if (id != purchaserPage.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(purchaserPage);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PurchaserPageExists(purchaserPage.ID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction("Index");
      }
      return View(purchaserPage);
    }

    // GET: PurchaserPages/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var purchaserPage = await _context.PurchaserPage.SingleOrDefaultAsync(m => m.ID == id);
      if (purchaserPage == null)
      {
        return NotFound();
      }

      return View(purchaserPage);
    }

    // POST: PurchaserPages/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var purchaserPage = await _context.PurchaserPage.SingleOrDefaultAsync(m => m.ID == id);
      _context.PurchaserPage.Remove(purchaserPage);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    private bool PurchaserPageExists(int id)
    {
      return _context.PurchaserPage.Any(e => e.ID == id);
    }
  }
}
