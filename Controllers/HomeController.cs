using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;

namespace application.Controllers
{
    public class ExampleOfDTO{
        public int SalesCount {get; set;}
        public string msg {get; set;}
    }

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ExampleOfDTO Get()    
        {
            var result=new ExampleOfDTO();
            try{
                result.SalesCount = _context.Sales.Count();
            }
            catch(Exception e)
            {
                result.msg=e.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("Migrate")]
        public string Migrate()
        {
            try
            {
                _context.Database.Migrate();
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "OK";
        }

    }

}