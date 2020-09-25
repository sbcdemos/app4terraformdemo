using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;

namespace application.Controllers
{
    public class ExampleOfDTO{
        public int ItemsCount {get; set;}
        public string msg {get; set;}
    }
    [ApiController]
    [Route("")]
    public class TheRootController: ControllerBase
    {
        IConfiguration _config;
        public TheRootController(IConfiguration configuration)
        {
            this._config=configuration;
        }
        public string Get(){
            return "OK from ROOT:"+_config.GetSection("ConnectionStrings")["SalesDatabase"];//Environment.GetEnvironmentVariable("ConnectionStrings:SalesDatabase");
        }
    }


    [ApiController]
    [Route("Stats")]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ExampleOfDTO Get()    
        {
            
            var result=new ExampleOfDTO();
            try{
                result.ItemsCount = _context.Clients.Count();
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