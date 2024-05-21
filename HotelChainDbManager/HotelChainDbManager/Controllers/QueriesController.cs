using HotelChainDbManager.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelChainDbManager.Controllers;

public class QueriesController : Controller
{
    private readonly HotelChainDbContext _context;

    public QueriesController(HotelChainDbContext context)
    { 
        _context = context;
    }


    public IActionResult SimpleQuery1()
    { 
        
    }

    public IActionResult Index()
    {
        return View();
    }
}
