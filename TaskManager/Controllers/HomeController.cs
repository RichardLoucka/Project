using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return View(tasks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Task task, IFormFile file)
    {
        if (file != null)
        {
            task.FileName = file.FileName;
        }
        
        if (string.IsNullOrEmpty(task.FileName))
        {
            task.FileName = "";  
        }
        _context.Add(task);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int[] selectedTasks)
    {
        if (selectedTasks != null && selectedTasks.Any())
        {
            var tasksToRemove = _context.Tasks.Where(t => selectedTasks.Contains(t.Id)).ToList();

            if (tasksToRemove.Any())
            {
                _context.Tasks.RemoveRange(tasksToRemove);
                await _context.SaveChangesAsync();
            }
        }

        return RedirectToAction(nameof(Index));  
    }
}