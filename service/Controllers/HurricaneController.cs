using System;
using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Data;

namespace service.Controllers
{
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
            //Initiates an instance of HurricaneData and assigns it to the property _context, working as a data source for the application
            HurricaneData context = new HurricaneData();
            _context = context;
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

        //Creates a GetLandfalls controller that returns all landfalls
        [HttpGet("landfalls")]
        public List<Landfall> GetLandfalls()
        {
            //Assigns a List of Landfalls to the List of Landfalls kepy in the instance of HurricaneData
            List<Landfall> landfalls = _context.Landfalls;

            //Returns the List of Landfalls
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
}