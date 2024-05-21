using HotelChainDbManager.Data;
using HotelChainDbManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HotelChainDbManager.Controllers;

public class QueriesController : Controller
{
    private readonly HotelChainDbContext _context;

    private readonly string sQuery1Path = "Simple1.sql";

    private readonly string sQuery2Path = "Simple2.sql";

    private readonly string sQuery3Path = "Simple3.sql";

    private readonly string sQuery4Path = "Simple4.sql";

    private readonly string sQuery5Path = "Simple5.sql";

    private readonly string cQuery1Path = "Comparison1.sql";

    private readonly string cQuery2Path = "Comparison2.sql";

    private readonly string cQuery3Path = "Comparison3.sql";

    private readonly string conStr = "Server=WIN-9RCA4H5E5KS\\SQLEXPRESS; Database=DBHotelChain; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=True;";

    public QueriesController(HotelChainDbContext context)
    { 
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SQuery1Input()
    {
        return View();
    }

    public IActionResult SQuery2Input()
    {
        return View();
    }

    public IActionResult SQuery3Input()
    {
        return View();
    }

    public IActionResult SQuery4Input()
    {
        return View();
    }

    public IActionResult SQuery5Input()
    {
        return View();
    }

    public IActionResult CQuery1Input()
    {
        return View();
    }

    public IActionResult CQuery2Input()
    {
        return View();
    }

    public IActionResult CQuery3Input()
    {
        return View();
    }

    public IActionResult SQuery1Output(SQuery1Input queryModel)
    {
        string query = System.IO.File.ReadAllText(sQuery1Path);

        query = query.Replace("HOTEL_NUMBER", "@HotelNumber");
        query = query.Replace("CLASS_NAME", "@ClassName");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<SQuery1Output> result = new List<Models.SQuery1Output> ();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HotelNumber", queryModel.HotelNumber);
                command.Parameters.AddWithValue("@ClassName", queryModel.ClassName);

                using (var reader = command.ExecuteReader())
                {
                    int flag = 0;
                    while (reader.Read())
                    {
                        result.Add(new Models.SQuery1Output { RoomNumber = int.Parse(reader.GetString(0)) });
                        flag++;
                    }

                    if (flag == 0)
                    {
                        NotFound();
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }
}
