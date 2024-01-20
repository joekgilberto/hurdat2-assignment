using service;
using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Data;

namespace service.Controllers;

[ApiController]
//Creates a route of "huricane"
[Route("[controller]")]
public class HurricaneController : ControllerBase
{
    //Creates a property of _context to hold an instance of HurricaneData
    private readonly HurricaneData _context;

    //Creates a constructor for HurricaneController
    public HurricaneController()
    {
        //Upon creation, initiates an instance of HurricaneData and assigns it to the property _context, working as a data source for the application
        _context = new HurricaneData();
    }

    //Creates a GetAll controller that returns all hurricanes
    [HttpGet("all")]
    public List<Hurricane> GetAll()
    {
        //Creates a hurricanes variable that calls all Hurricanes stored in _context.Hurricanes (an instance of HurricaneData)
        List<Hurricane> hurricanes = _context.Hurricanes;

        //Returns said hurricanes variable
        return hurricanes;
    }

    [HttpGet("{ATCFCode}")]
    public Hurricane GetByATCFCode(string ATCFCode)
    {
        List<Hurricane> hurricanes = _context.Hurricanes.Where(h => h.FullATCFCode() == ATCFCode).ToList();

        List<Hurricane> foundHurricanes = hurricanes.Where(h => h.LandedInFlorida()).ToList();

        return hurricanes[0];
    }

    [HttpGet("florida")]
    public List<Hurricane> GetFlorida()
    {
        //Assigns the complete list of Hurricanes from the data set to the variable hurricanes
        List<Hurricane> hurricanes = _context.Hurricanes;

        //Queries the complete list of Hurricanes by checking it against the .IsHurricane() and .Landed() methods from Tools, while checking that its year is from after 1900
        List<Hurricane> landfalls = hurricanes.Where(h => h.LandedInFlorida() && h.Year > 1900).ToList();

        //Returns said list of hurricanes
        return landfalls;
    }

    [HttpGet("test")]
    public string GetTest()
    {
        return "test";
    }
}

