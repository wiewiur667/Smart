using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smart.Models.Api.Interfaces;
using SmartBowl;
using System.Collections.Generic;
using Smart.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Smart.Controllers.Api
{
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private IPetRepository _petRepository;

        public PetController(IPetRepository repository)
        {
            _petRepository = repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            var item = await Task.Run(() =>
            {
                return _petRepository.Get();
            });
                
            var result = JsonConvert.SerializeObject(item, new JsonSerializerSettings
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
                return _petRepository.GetPet(id);
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

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Pet pet)
        {
            var entity = await Task.Run(() =>
            {
                return _petRepository.AddPet(pet);
            });

            return new ObjectResult(entity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Pet value)
        {
            if(value == null || _petRepository.GetPet(id) == null){
                return BadRequest();
            }

            var entity = await Task.Run(() =>
            {
                return _petRepository.Update(id, value);
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
                return _petRepository.Delete(id);

            });

            if(entity == null)
            {
                return NotFound();
            }
            
            return new NoContentResult();

        }
        
    }
}
