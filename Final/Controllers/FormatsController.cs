using Final.Models;
using Final.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Final.Controllers
{
    public class FormatsController : Controller
    {
        private FinalContext _Context;
        // GET: FormatsController
        public FormatsController(FinalContext context)
        {
            this._Context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _Context.Formats.Include(x => x.SeriesEntries).ToListAsync());
        }

        // GET: FormatsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: FormatsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormatsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Format format)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Format format1 = new Format
                    {
                        FormatName = format.FormatName
                    };

                    _Context.Add(format1);
                    await _Context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                // If the model state is not valid, return to the create view
                return View(format);
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var format=await _Context.Formats.FirstOrDefaultAsync(x=>x.FormatId==id);
            Format format1 = new Format()
            {
                FormatId=format.FormatId,
                FormatName=format.FormatName
            };
            return View(format);
        }

        // POST: Formats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Format format)
        {
            Format format1 = new Format
            {
                
FormatId=format.FormatId,
FormatName=format.FormatName
            };
            _Context.Update(format1);
            _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: FormatsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var format = await _Context.Formats.FirstOrDefaultAsync(x => x.FormatId == id);
            _Context.Remove(format);
            await _Context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
