using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartBowl;
using Smart.Models.Api;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Smart.Controllers.Api
{

    [Route("api/[controller]")]
    public class BowlController : Controller
    {
        private readonly IBowlRepository _bowlRepository;

        public BowlController (IBowlRepository bowlRepository)
        {
            _bowlRepository = bowlRepository;
        }

        [HttpGet]
        public IEnumerable<Bowl> GetAllBowls()
        {
            return _bowlRepository.GetAll();
        }

        [HttpGet("{id:int}", Name ="GetBowlById")]
        public IActionResult GetBowlById(int id)
        {
            Bowl b =  _bowlRepository.Find(id);

            if(b == null)
            {
                return NotFound();
            }

            return new ObjectResult(b);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Bowl bowl)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return new ObjectResult("Is Invalid" + bowl.ToString());
            }else
            {
                var addedBowl = _bowlRepository.Add(bowl);

                if (addedBowl != null)
                {
                    string url = Url.RouteUrl("GetBowlById", new { id = addedBowl.ID }, Request.Scheme, Request.Host.ToUriComponent());
                    Response.StatusCode = 201;
                    Response.Headers["Location"] = url;
                    return new ObjectResult(addedBowl);
                }
                else
                {
                    Response.StatusCode = 400;
                    return new ObjectResult("Failed To Add Bowl");
                }
            }
        }
    }
}
