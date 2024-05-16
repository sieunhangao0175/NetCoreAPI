using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using NetMVC.Models.Process;
using OfficeOpenXml;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
{
    private readonly ApplicationDbcontext _context;
    public PersonController(ApplicationDbcontext context)
    {
        _context = context;
    }
    public ExcelProcess _excelProcess = new ExcelProcess();
    public async Task<IActionResult> Index()
    {
        var model =  _context.Person.ToListAsync();
        return View(model);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(string SearchString)
    {
        var model = await _context.Person.Where(e => e.fullname.Contains(SearchString)).ToListAsync();
        return View(model);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PersonId,FullName,Address")] Person person)
    {
        if (ModelState.IsValid)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        return View(person);

    }
    public async Task<IActionResult>Edit(string id)
    {
        if (id == null || _context.Person == null)
        {
            return NotFound();
        }
        var person = await _context.Person.FindAsync(id);
        if (person == null)
        {
            return NotFound();

        }
        return View(person);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    
    public async Task<IActionResult> Edit(string id, [Bind("PersonId,FullName,Address")] Person person)
    {
        if (id !=person.PersonID)
        {
            return NotFound();

        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(person);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(person.PersonID))
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
        return View(person);
    }
 public async Task<IActionResult> Delete(string id)
 { 
    if (id == null || _context.Person == null)
    {
        return NotFound();
    }
    var person = await _context.Person
    .FirstOrDefaultAsync(m => m.PersonID == id);
    if (person == null)
    {
        return NotFound();
    }
    return View(person);
 }
 [HttpPost, ActionName("Delete")]
 [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(string id)
  {
    if (_context.Person == null)
    {
        return Problem("Entity set 'ApplicationDbContext.Person' is null.");
    }
    var person = await _context.Person.FindAsync(id);
    if (person != null)
    {
        _context.Person.Remove(person);
    }
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }
  public async Task<IActionResult> Upload()
  {
    return View();
  }
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Upload(IFormFile file)
  {
    if(file!=null)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        if(fileExtension != ".xls" && fileExtension != ".xlsx")
        {
            ModelState.AddModelError("", "Please choose excel file to upload !!!");
        }
        else
        {
                //rename fle when upload to sever
                var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Upload/Excels", FileName);
                var fileLocation = new FileInfo(filePath).ToString();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //save file to sever
                    await file.CopyToAsync(stream);
                    //read data from excel file fil datatable 
                    var dt = _excelProcess.ExcelToDataTable(fileLocation);
                    //using for loop to read data from dt
                    for ( int i = 0; i < dt.Rows.Count; i++)
                    {
                        var ps = new Person();
                        ps.PersonID = dt.Rows[i][0].ToString();
                        ps.fullname = dt.Rows[i][1].ToString();
                        ps.address = dt.Rows[i][2].ToString();
                        _context.Add(ps);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            } 
        }
    return View();
  }
  public ActionResult Download()
  {
    var fileName = "YourFileName" + ".xlsx";
    using(ExcelPackage excelPackage = new ExcelPackage())
    {
        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
        worksheet.Cells["A1"].Value = "PersonId";
        worksheet.Cells["B1"].Value = "FullName";
        worksheet.Cells["C1"].Value = "Address";
         var personList = _context.Person.ToList();
         worksheet.Cells["A2"].LoadFromCollection(personList);
         var steam = new MemoryStream(excelPackage.GetAsByteArray());
         return File(steam, "application/vn.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }
  }
  private bool PersonExists(string id)
  {
    return (_context.Person?.Any(e => e.PersonID == id)).GetValueOrDefault();
  }
}

    public class ExcelProcess
    {
    }
}