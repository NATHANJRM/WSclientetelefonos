using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSclientetelefonos.ServiceReference1;

namespace WSclientetelefonos.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            using (WebServiceCEL1SoapClient ws = new WebServiceCEL1SoapClient())
            {
                List<celularesext> list = ws.obtenercel().ToList();
                return View(list);
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            using (WebServiceCEL1SoapClient ws = new WebServiceCEL1SoapClient())
            {
                List<marcasext> list = ws.obtenermar().ToList();
                ViewBag.idmarca = new SelectList(list, "id", "marca");
            }
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(celularesext cel)
        {
            try
            {
                using (WebServiceCEL1SoapClient ws = new WebServiceCEL1SoapClient())
                {
                    ws.agregar(cel);
                    return RedirectToAction("Index");
                }
                    // TODO: Add insert logic here

                    
            }
            catch
            {
                return View();
            }
        }

        //GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (WebServiceCEL1SoapClient ws = new WebServiceCEL1SoapClient())
            {
                celularesext cel = ws.obtenerid(id);

                List<marcasext> list = ws.obtenermar().ToList();
                ViewBag.idmarca = new SelectList(list, "id", "marca", cel.idmarca);

                return View(cel);
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(celularesext cel)
        {
            using (WebServiceCEL1SoapClient ws = new WebServiceCEL1SoapClient())
            {
                try
                {
                    ws.edit(cel);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                } 
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (WebServiceCEL1SoapClient ws = new WebServiceCEL1SoapClient())
                {
                    ws.delete(id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
