using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LVC.Models;
using LVC.Models.ViewModels;

namespace LVC.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly LTQLDb _context;

        public SinhVienController(LTQLDb context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            var lTQLDb = _context.SinhVien.Include(s => s.LopHoc);
            return View(await lTQLDb.ToListAsync());
        }

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.LopHoc)
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop");
            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,HoTen,MaLop")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSinhVien,HoTen,MaLop")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSinhVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.LopHoc)
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhVien.Any(e => e.MaSinhVien == id);
        }
        public async Task<IActionResult> Index2(int MaLop){
            MaLop=1;
            var query = (from std in  _context.SinhVien
                         join lophoc in _context.LopHoc
                         on std.MaLop equals lophoc.MaLop
                         where std.MaLop==MaLop
                         select new SinhVienVM{
                            MaSinhVien=std.MaSinhVien,
                            HoTen=std.HoTen,
                            MaLop=lophoc.MaLop,
                            TenLop=lophoc.TenLop,
                         }).ToList().Take(2);
            return View(query);
        }
        
       
        
    }
}
