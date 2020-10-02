using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OO1Classlibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObOpgave4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FanOutputController : ControllerBase
    {
        private static int _id = 1;

        public static int ID
        {
            get => _id++;
            set => _id = value;
        }

        private static readonly Random rng = new Random();

        private static readonly List<FanOutput> fanOutputs = new List<FanOutput>()
        {
            new FanOutput(ID,"Exhaust",rng.Next(15,25),rng.Next(30,80)),
            new FanOutput(ID,"Exhaust",rng.Next(15,25),rng.Next(30,80)),
            new FanOutput(ID,"Intake",rng.Next(15,25),rng.Next(30,80)),
            new FanOutput(ID,"Exhaust",rng.Next(15,25),rng.Next(30,80)),
        };

        // GET: api/<FanOutputController>
        [HttpGet]
        public IEnumerable<FanOutput> Get()
        {
            return fanOutputs;
        }

        // GET api/<FanOutputController>/5
        [HttpGet("{id}")]
        public FanOutput Get(int id)
        {
            return fanOutputs.Find(fo => fo.ID == id);
        }

        // POST api/<FanOutputController>
        [HttpPost]
        public void Post([FromBody] FanOutput value)
        {
            fanOutputs.Add(new FanOutput(ID,value.Name,value.Temp,value.Humidity));
        }

        // PUT api/<FanOutputController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutput value)
        {
            FanOutput fo = Get(id);
            if (fo != null)
            {
                fo.Humidity = value.Humidity;
                fo.Name = value.Name;
                fo.Temp = value.Temp;
            }

        }

        // DELETE api/<FanOutputController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutput fo = Get(id);
            fanOutputs.Remove(fo);
        }
    }
}
