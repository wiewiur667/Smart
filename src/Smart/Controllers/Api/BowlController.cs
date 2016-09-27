using Microsoft.AspNetCore.Mvc;
using Smart.Models.Api.Interfaces;
using System.Threading.Tasks;
using SmartBowl;
using Smart.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Smart.Controllers.Api
{
    [Route("api/[controller]")]
    public class BowlController : Controller
    {
        private IBowlRepository _bowlRepository;

        public BowlController(IBowlRepository bowlRepository)
        {
            _bowlRepository = bowlRepository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetBowls()
        {
            var bowls = _bowlRepository.Get();

            string result = JsonConvert.SerializeObject(bowls, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(result, "application/json");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await Task.Run(() =>
            {
                return _bowlRepository.GetBowl(id);
            });

            if (item == null)
            {
                return NotFound();
            }

            var result = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(result, "application/json");

        }

        [HttpGet("{id}/lock/{locked:bool?}")]
        public async Task<IActionResult> Lock(int id, bool? locked)
        {
            if (locked == null)
            {
                return BadRequest();
            }
            else
            { 
                var entity = await Task.Run(() =>
                {
                    _bowlRepository.LockBowl(id, (bool)locked);
                    return _bowlRepository.GetBowl(id);
                });

                if (entity == null)
                {
                    return NotFound();
                }

                return new NoContentResult();
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Bowl bowl)
        {
            var entity = await Task.Run(() =>
            {
                return _bowlRepository.AddBowl(bowl);
            });

            return new ObjectResult(entity);
        }

        

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Bowl value)
        {
            if(value == null || _bowlRepository.GetBowl(id) == null)
            {
                return BadRequest();
            }

            var entity = await Task.Run(() =>
            {
               return _bowlRepository.Update(id, value);
               
            });

            if(entity == null)
            {
                return NotFound();
            }

            return new NoContentResult();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await Task.Run(() =>
            {
                return _bowlRepository.Delete(id);

            });

            if (entity == null)
            {
                return NotFound();
            }

            return new NoContentResult();

        }
    }
}
