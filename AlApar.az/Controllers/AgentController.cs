using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlApar.az.Model;

namespace AlApar.az.Controllers
{
    public class AgentController : Controller
    {
        alaparSql2Entities db = new alaparSql2Entities();

        // GET: Agent
        public ActionResult Index(int id)
        {
            DataBaseForHome data = new DataBaseForHome();
            data.Elanler = db.Ads.Where(w => w.AgentId == id && w.StartDate < DateTime.Now && w.EndDate > DateTime.Now).ToList();
            data.Sekiller = db.Images.ToList();
            return View(data);

        }

        public ActionResult List()
        {
            List<Agent> agentler = db.Agents.ToList();

            return View(agentler);
        }
    }
}