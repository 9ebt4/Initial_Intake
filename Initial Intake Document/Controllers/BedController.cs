using Initial_Intake_Document.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Initial_Intake_Document.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {
        ShelterDbContext db = new ShelterDbContext();
        [HttpGet]
        public List<Bed> GetBeds()
        {
            return db.Beds.ToList();
        }
        //[HttpPatch]
        //public Bed ChangeBed(Patron? patron, Bed bed) 
        //{
        //    Bed modifiedBed = db.Beds.Where(b => b.BedId == bed.BedId).FirstOrDefault();
        //    modifiedBed.Patrons.Clear();
        //    if(patron != null)
        //    {
        //        modifiedBed.Patrons.Add(patron);
        //    }
        //    db.Beds.Update(modifiedBed);
        //    db.SaveChanges();
        //    return modifiedBed;
        //}
    }
}
