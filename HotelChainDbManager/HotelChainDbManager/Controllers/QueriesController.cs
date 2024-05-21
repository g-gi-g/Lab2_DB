using HotelChainDbManager.Data;
using HotelChainDbManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HotelChainDbManager.Controllers;

public class QueriesController : Controller
{
    private readonly HotelChainDbContext _context;

    private readonly string sQuery1Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Simple1.sql";

    private readonly string sQuery2Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Simple2.sql";

    private readonly string sQuery3Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Simple3.sql";

    private readonly string sQuery4Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Simple4.sql";

    private readonly string sQuery5Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Simple5.sql";

    private readonly string cQuery1Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Comparison1.sql";

    private readonly string cQuery2Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Comparison2.sql";

    private readonly string cQuery3Path = @"E:\\БДтаІС\\Lab2_DB\\Lab2_DB\\HotelChainDbManager\\HotelChainDbManager\\Queries\\Comparison3.sql";

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

        List<SQuery1Output> result = new List<SQuery1Output> ();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HotelNumber", queryModel.HotelNumber);
                command.Parameters.AddWithValue("@ClassName", queryModel.ClassName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SQuery1Output { RoomNumber = reader.GetInt32(0) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult SQuery2Output(SQuery2Input queryModel)
    {
        string query = System.IO.File.ReadAllText(sQuery2Path);

        query = query.Replace("HOTEL", "@HotelNumber");
        query = query.Replace("POS_NAME", "@PositionName");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<SQuery2Output> result = new List<SQuery2Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HotelNumber", queryModel.HotelNumber);
                command.Parameters.AddWithValue("@PositionName", queryModel.PositionName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SQuery2Output { IdCardNumber = reader.GetInt32(0), Name = reader.GetString(1), Surname = reader.GetString(2) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult SQuery3Output(SQuery3Input queryModel)
    {
        string query = System.IO.File.ReadAllText(sQuery3Path);

        query = query.Replace("CLASS_NAME", "@ClassName");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<SQuery3Output> result = new List<SQuery3Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClassName", queryModel.ClassName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SQuery3Output { IdCardNumber = reader.GetInt32(0) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult SQuery4Output(SQuery4Input queryModel)
    {
        string query = System.IO.File.ReadAllText(sQuery4Path);

        query = query.Replace("HOTEL_ADDRESS", "@HotelAddress");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<SQuery4Output> result = new List<SQuery4Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HotelAddress", queryModel.Address);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SQuery4Output { IdCardNumber = reader.GetInt32(0), Name = reader.GetString(1), Surname = reader.GetString(2) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult SQuery5Output(SQuery5Input queryModel)
    {
        string query = System.IO.File.ReadAllText(sQuery5Path);

        query = query.Replace("RATE", "@Rate");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<SQuery5Output> result = new List<SQuery5Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Rate", queryModel.WorkingRate);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new SQuery5Output { IdCardNumber = reader.GetInt32(0), Name = reader.GetString(1), Surname = reader.GetString(2) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult CQuery1Output(CQuery1Input queryModel)
    {
        string query = System.IO.File.ReadAllText(cQuery1Path);

        query = query.Replace("HOTEL_NUMBER", "@HotelNumber");
        query = query.Replace("ROOM_NUMBER", "@RoomNumber");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<CQuery1Output> result = new List<CQuery1Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@HotelNumber", queryModel.HotelNumber);
                command.Parameters.AddWithValue("@RoomNumber", queryModel.RoomNumber);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CQuery1Output { RoomNumber = reader.GetInt32(0), HotelNumber = reader.GetInt32(1) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult CQuery2Output(CQuery2Input queryModel)
    {
        string query = System.IO.File.ReadAllText(cQuery2Path);

        query = query.Replace("ID", "@ResidentId");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<CQuery2Output> result = new List<CQuery2Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ResidentId", queryModel.IdCardNumber);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CQuery2Output { IdCardNumber = reader.GetInt32(0) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }

    public IActionResult CQuery3Output(CQuery3Input queryModel)
    {
        string query = System.IO.File.ReadAllText(cQuery3Path);

        query = query.Replace("POS_NAME", "@PositionName");
        query = query.Replace("\r\n", " ");
        query = query.Replace('\t', ' ');

        List<CQuery3Output> result = new List<CQuery3Output>();

        using (var connection = new SqlConnection(conStr))
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PositionName", queryModel.PositionName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CQuery3Output { IdCardNumber = reader.GetInt32(0) });
                    }
                }
            }
            connection.Close();
        }

        return View(result);
    }
}
