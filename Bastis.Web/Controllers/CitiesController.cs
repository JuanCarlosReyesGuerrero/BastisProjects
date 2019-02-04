using Bastis.Data.Entities;
using Bastis.Service;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bastis.Controllers
{
    public class CitiesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ServiceBase serviceBase = new ServiceBase();

        // GET: Cities
        public ActionResult Index()
        {
            // var cities = db.Cities.Include(c => c.State);
            var cities = serviceBase.CityRepository.GetAll(includeProperties: "State");
            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //City city = db.Cities.Find(id);
            City city = serviceBase.CityRepository.GetByID(id);

            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            //ViewBag.StateID = new SelectList(db.States, "ID", "Code");
            PopulateStatesDropDownList();
            return View();
        }

        // POST: Cities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,Name,UnifiedCode,StateID,StateCode,Status,UserRegisters,DateRegister,UserModifies,DateModified")] City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Cities.Add(city);
                    //db.SaveChanges();

                    serviceBase.CityRepository.Insert(city);
                    serviceBase.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                // throw;
            }

            //ViewBag.StateID = new SelectList(db.States, "ID", "Code", city.StateID);
            //return View(city);

            PopulateStatesDropDownList(city.StateID);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //City city = db.Cities.Find(id);
            City city = serviceBase.CityRepository.GetByID(id);

            if (city == null)
            {
                return HttpNotFound();
            }
            //ViewBag.StateID = new SelectList(db.States, "ID", "Code", city.StateID);
            PopulateStatesDropDownList(city.StateID);
            return View(city);
        }

        // POST: Cities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,Name,UnifiedCode,StateID,StateCode,Status,UserRegisters,DateRegister,UserModifies,DateModified")] City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(city).State = EntityState.Modified;
                    //db.SaveChanges();
                    serviceBase.CityRepository.Update(city);
                    serviceBase.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                //throw;
            }

            PopulateStatesDropDownList(city.StateID);
            //ViewBag.StateID = new SelectList(db.States, "ID", "Code", city.StateID);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //City city = db.Cities.Find(id);
            City city = serviceBase.CityRepository.GetByID(id);

            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //City city = db.Cities.Find(id);
            //db.Cities.Remove(city);
            //db.SaveChanges();
            City city = serviceBase.CityRepository.GetByID(id);
            serviceBase.CityRepository.Delete(id);
            serviceBase.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                serviceBase.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateStatesDropDownList(object selectedState = null)
        {
            var statesQuery = serviceBase.StateRepository.GetAll(
                orderBy: q => q.OrderBy(d => d.Name));
            ViewBag.StateID = new SelectList(statesQuery, "StateID", "Name", selectedState);
        }
    }
}
