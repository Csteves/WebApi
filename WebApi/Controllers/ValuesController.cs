using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get([FromQuery]int id ,string query)
        {
            return $"value={id}, query={query}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Invalid");
            }
            Console.WriteLine("Hello from Post: Id = {0} & Text={1}",value.Id,value.Text);
            Console.WriteLine("Hello from Value2: Id = {0} & Text={1} $ Text2 = {2}",value.Value2.Id ,value.Value2.StrArray[0], value.Value2.StrArray[1]);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Value
    {
        [Range(0,1000)]
        public int Id { get; set; }
        [MinLength(3)]
        public string Text { get; set; }
        public Value2 Value2 { get; set; }

    }

    public class Value2
    {
        public int Id { get; set; }
        public string[] StrArray { get; set; }
    }
}
