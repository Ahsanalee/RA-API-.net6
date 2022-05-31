using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RA_ApiController : ControllerBase
    {
    //    private static List<RA_Tech> RaS = new List<RA_Tech>
    //        {
             
    //            new RA_Tech{
    //            Id=2,
    //            FirstName="Amir",
    //            LastName="Khan",
    //            Place="Lahor"
    //        }
    //      };
        private readonly DataContext _context;

        public RA_ApiController(DataContext Context)
        {
            _context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RA_Tech>>> Get()
        {
          
            return Ok(await _context.RAs.ToListAsync()); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RA_Tech>> Get(int id)
        {
            var Tech = await _context.RAs.FindAsync(id)  ;
            if(Tech == null)
            
                return BadRequest("Employee not found"); 
           return Ok(Tech);
        }

        [HttpPost]
        public async Task<ActionResult<List<RA_Tech>>> Addemployee(RA_Tech Tech)
        {
            _context.RAs.Add(Tech);
            await _context.SaveChangesAsync();  
            return Ok(await _context.RAs.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<RA_Tech>>> Updateemployee(RA_Tech request)
        {
            var dbTech = await _context.RAs.FindAsync(request.Id);
            if (dbTech == null)

                return BadRequest("Employee not found");
           
            dbTech.FirstName = request.FirstName; 
            dbTech.LastName = request.LastName;
            dbTech.Place = request.Place;  

            await _context.SaveChangesAsync();  
            return Ok(await _context.RAs.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RA_Tech>>> Delete(int id)
        {
            var dbtech = await _context.RAs.FindAsync(id);  
            if (dbtech == null)
                return BadRequest("Employee not found");
            _context.RAs.Remove(dbtech);
            await _context.SaveChangesAsync();  
            return Ok(await _context.RAs.ToListAsync());
        }

    }

}
