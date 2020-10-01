using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;


namespace application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WFController : ControllerBase
    {
        private readonly DataContext _context;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WFController> _logger;

        public WFController(ILogger<WFController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rand=new Random();

            var x=rand.Next(7);
            switch (x) {
                case 0: 
                    var client = new Client{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients.Add(client);
                    break;
                case 1: 
                    var client1 = new Client1{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients1.Add(client1);
                    break;
                case 2: 
                    var client2 = new Client2{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients2.Add(client2);
                    break;
                case 3: 
                    var client3 = new Client3{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients3.Add(client3);
                    break;
                case 4: 
                    var client4 = new Client4{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients4.Add(client4);
                    break;
                case 5: 
                    var client5 = new Client5{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients5.Add(client5);
                    break;
                case 6: 
                    var client6 = new Client6{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients6.Add(client6);
                    break;
                default: 
                    var clientX = new Client{
                        Name="Client "+(new Random()).Next(100000000).ToString("d8")
                    };
                    _context.Clients.Add(clientX);
                    break;
                    
            }
            //_context.Clients.Add(client);
            _context.SaveChanges();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
