using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FileUplaoder.Models;

namespace FileUplaoder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    //Get:: / -> it will directly display fileuplaod page.
    public IActionResult Index()
    {
        return View("FileUplaod");
    }

    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //Get:: /Home/FileUplaod
    //public IActionResult FileUplaod()
    //{
    //    return View();
    //}

    //Post:: /Home/FileUplaod
    [HttpPost]
    public IActionResult FileUplaod(IFormFile file)
    {
        try
        {

            StreamReader st = new StreamReader(file.OpenReadStream()); //reading the file as a stream
            string[] texts = st.ReadLine().Split("\n");
            System.IO.File.AppendAllText("./master.txt", texts[0] + '\n');
            st.Close(); //closing the stram to release used resources.
            return View("Success");

        }
        catch
        {
            return View("Error");

        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

