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

    //Creates a GetByATCFCode controller that returns a specific hurricane called by an ATCF Code, accepting a string labeled ATCFCode
    [HttpGet("{ATCFCode}")]
    public List<Hurricane> GetByATCFCode(string ATCFCode)
    {
        //Returns a list of hurricanes where the hurricane's ATCF Code equeals the inputed string, which only includes one matching hurricane
        List<Hurricane> hurricane = _context.Hurricanes.Where(h => h.ATCFCode == ATCFCode).ToList();

        //Returns the found hurricane in list form (or an empty list if no hurricane is found)
        return hurricane;
    }

    //Creates a GetFlorida controller that returns all hurricanes that have landed in Florida during or after 1900
    [HttpGet("florida")]
    public List<Hurricane> GetFlorida()
    {
        //Assigns the complete list of Hurricanes from the data set to the variable hurricanes
        List<Hurricane> hurricanes = _context.Hurricanes;

        //Queries the complete list of Hurricanes by checking it against the class's .LandedInFlorida() method and checking that the year is 1900 or onward
        List<Hurricane> landfalls = hurricanes.Where(h => h.LandedInFlorida() && h.Year > 1900).ToList();

        //Returns said list of hurricanes
        return landfalls;
    }

    //Creates a GetTest test controller that returns the string "test" to help developers ensure the application is running
    [HttpGet("test")]
    public string GetTest()
    {
        //Returns a string, "test"
        return "test";
    }
}

