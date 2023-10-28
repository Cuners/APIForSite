using Microsoft.AspNetCore.Mvc;
using ISRPO4CURS.Model;
using Microsoft.EntityFrameworkCore;

namespace ISRPO4CURS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private Isrpo4cContext? _srpo4cContext;
        public HomeController(Isrpo4cContext isrpo4CContext)
        {
            _srpo4cContext = isrpo4CContext;
        }
        [HttpGet]
        [Route("/getArticle")]
        public async Task<ActionResult<IEnumerable<Bludum>>> Get()
        {
            return await _srpo4cContext.Bluda.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Bludum>>> Get(int id)
        {
            Bludum bluda = await _srpo4cContext.Bluda.FirstOrDefaultAsync(x => x.IdBludo == id);
            if (bluda == null)
                return NotFound();
            return new ObjectResult(bluda);
        }
        /* public string Get(int id)
         {
             return "value";
         }*/

        // POST api/<CutomersController>
        [HttpPost]
        public async Task<ActionResult<Bludum>> Post(Bludum bluda)
        {
            if (bluda == null)
            {
                return BadRequest();
            }
            _srpo4cContext.Bluda.Add(bluda);
            await _srpo4cContext.SaveChangesAsync();
            return Ok(bluda);
        }
        /*public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<CutomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Bludum>> Put(Bludum bluda)
        {
            if (bluda == null)
            {
                return BadRequest();
            }
            if (!_srpo4cContext.Bluda.Any(x => x.IdBludo == bluda.IdBludo))
            {
                return NotFound();
            }
            _srpo4cContext.Update(bluda);
            await _srpo4cContext.SaveChangesAsync();
            return Ok(bluda);
        }
        /* public void Put(int id, [FromBody] string value)
         {
         }*/

        // DELETE api/<CutomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bludum>> Delete(int id)
        {
            Bludum bluda = _srpo4cContext.Bluda.FirstOrDefault(x => x.IdBludo == id);
            if (bluda == null)
            {
                return NotFound();
            }
            _srpo4cContext.Bluda.Remove(bluda);
            await _srpo4cContext.SaveChangesAsync();
            return Ok(bluda);
        }
        /*public void Delete(int id)
        {
        }*/

    }
}
