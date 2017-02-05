using Council_Tracker.DAL;
using Council_Tracker.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Council_Tracker.Controllers
{
    public class OrdinanceController : ApiController
    {
        CTrackerRepository repo = new CTrackerRepository();
        // GET api/<controller>
        public List<Ordinance> Get()
        {
            return repo.GetOrds();
        }

        public Ordinance Get(int id)
        {
            return repo.GetSingleOrd(id);
        }
    }
}