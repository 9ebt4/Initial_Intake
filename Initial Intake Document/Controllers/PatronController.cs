using Initial_Intake_Document.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Initial_Intake_Document.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronController : ControllerBase
    {
        ShelterDbContext db = new ShelterDbContext();
        [HttpGet]
        public List<Patron> GetPatrons()
        {
            return db.Patrons.ToList();
        }
        
        [HttpGet("{id}")]
        public Patron GetPatron(int id)
        {
            return db.Patrons.FirstOrDefault(p => p.PatronId == id);
        }
        
        [HttpGet("Name")]
        public Patron GetPatron(string name)
        {
            string modifiedName = name.ToLower().Trim();
            return db.Patrons.FirstOrDefault(p => p.FirstName.ToLower().Trim().Contains(modifiedName) || p.LastName.ToLower().Trim().Contains(modifiedName));
        }
    }
}
