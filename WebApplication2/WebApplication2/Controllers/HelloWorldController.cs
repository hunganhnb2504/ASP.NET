using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Welcome(string name, int numTimes = 4)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
    // 
    // GET: /HelloWorld/

    //public string Index()
    //{
    //    return "This is my default action...";
    ////}
    // 
    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    //public string Welcome(string name, int ID = 1)
    //{
    //    return HtmlEncoder.Default.Encode($"Hello {"Rick"}, ID: {1}");
    //}
}
