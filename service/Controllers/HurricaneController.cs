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
            //Assigns a List of Hurricanes to the List of Hurricanes kept in the instance of HurricaneData
            List<Hurricane> hurricanes = _context.Hurricanes;

            //Returns said hurricanes variable
            return hurricanes;
        }

        //Creates a GetLandfalls controller that returns all landfalls
        [HttpGet("landfalls")]
        public List<Landfall> GetLandfalls()
        {
            //Assigns a List of Landfalls to the List of Landfalls kept in the instance of HurricaneData
            List<Landfall> landfalls = _context.Landfalls;

            //Returns the List of Landfalls
            return landfalls;
        }

        //Creates a GetByATCFCode controller that returns a specific hurricane called by an ATCF Code, accepting a string parameter, ATCFCode
        [HttpGet("{ATCFCode}")]
        public List<Hurricane> GetByATCFCode(string ATCFCode)
        {
            //Returns a list of hurricanes where the hurricane's ATCF Code equeals the inputed string
            List<Hurricane> hurricane = _context.Hurricanes.Where(h => h.ATCFCode == ATCFCode).ToList();

            //Returns the found hurricane in list form (or an empty list if no hurricane is found)
            return hurricane;
        }
    }
}