using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlite_site.Data;
using sqlite_site.Models;

namespace sqlite_site.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SqliteDbContext _context;

    public IndexModel(ILogger<IndexModel> logger, SqliteDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        AccessLog accessLogEntry = new() { AccessedOn = DateTime.Now };
        _context.AccessLogs.Add(accessLogEntry);
        _context.SaveChangesAsync();

        AccessLogs = _context.AccessLogs.ToList<AccessLog>();

    }

    public List<AccessLog> AccessLogs { get; set; }
}
