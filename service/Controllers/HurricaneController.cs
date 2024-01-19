﻿using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Data;
using service.Utilities;

namespace service.Controllers;

[ApiController]
//Creates a route of "huricane"
[Route("[controller]")]
public class HurricaneController : ControllerBase
{
    //Creates a property of _context to hold an instance of HurricaneData
    private readonly HurricaneData _context;

    private readonly FloridaData _florida;

    //Creates a constructor for HurricaneController
    public HurricaneController()
    {
        //Upon creation, initiates an instance of HurricaneData and assigns it to the property _context, working as a data source for the application
        _context = new HurricaneData();
        _florida = new FloridaData();
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

    [HttpGet("florida")]
    public List<Hurricane> GetFlorida()
    {
        List<Hurricane> hurricanes = _context.Hurricanes;
        FloridaLandfall landfall = new FloridaLandfall();

        var landfalls = hurricanes.Where(h => landfall.Check(h) && h.Year > 1900);

        List <Hurricane> floridaHurricanes = landfalls.ToList();

        return floridaHurricanes;
    }

    [HttpGet("test")]
    public Object GetTest()
    {
        return _florida.Florida;
    }
}

