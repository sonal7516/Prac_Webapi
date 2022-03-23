using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prac_Webapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prac_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PandaExpController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDb;
        public PandaExpController(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var foods = applicationDb.pandaExpresses.ToList();
            return Ok(foods);
        }
        
        [HttpPost]
        public IActionResult Post(PandaExpress pandaExpress)
        {
            applicationDb.pandaExpresses.Add(pandaExpress);
            applicationDb.SaveChanges();
            return Ok(new { Ok = true, message="data entered successfully!"});
        }
    }

}
