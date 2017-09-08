using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCoreWebApi.DataServices;
using netCoreWebApi.DomainModel;

namespace netCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public IKeyValueService KeyValueService { get; set; }

        public ValuesController(IKeyValueService keyValueService)
        {
            KeyValueService = keyValueService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<KeyValue> GetAll()
        {
            var result = KeyValueService.GetAll();

            if (result != null)
            {
                return result;
            }
            else
            {
                //log something??

                return null;
            }
        }
                
        // GET api/values/5
        [HttpGet("{key}")]
        public KeyValue Get(string key)
        {  
            var result = KeyValueService.GetValue(key);

            if (result != null)
            {
                return result;
            }
            else
            {
                //log something??

                return null;
            }               
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]KeyValue value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            var result = KeyValueService.SetValue(value);

            if (result == KeyValueResponse.Created)
            {
                return Created(value.Key, value);
            }
            else
            {
                if (result == KeyValueResponse.Updated)
                {
                    return base.StatusCode(201, value);
                }
                else
                {
                    return base.BadRequest();
                }
            }            
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            if (key == null)
            {
                return BadRequest();
            }

            var result = KeyValueService.DeleteKey(key);

            if (result == KeyValueResponse.Deleted)
            {
                return base.Ok(key);
            }
            else
            {
                if (result == KeyValueResponse.NotFound)
                {
                    return base.NotFound(key);
                }
                else
                {
                    return base.BadRequest();
                }
            }            
        }
    }
}
