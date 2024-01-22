using System;
using Microsoft.AspNetCore.Mvc;

namespace service.Controllers
{
    [ApiController]
    //Creates an empty landing route
    [Route("")]
    public class HomeController : ControllerBase
    {
        //Creates a GetHome controller that returns a string
        [HttpGet("")]
        public string GetHome()
        {
            //returns the string "HURDAT2 parsed by Joe Gilberto"
            return "HURDAT2 parsed by Joe Gilberto";
        }
    }
}

