using ppedv.StrawberrySledgehammer.Logic;
using ppedv.StrawberrySledgehammer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class InstController : Controller
    {
        Core core = new Core();
        // GET: Inst
        public ActionResult Index()
        {
            return View(core.Repository.GetAll<Instrument>());
        }

        // GET: Inst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inst/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inst/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetById<Instrument>(id));
        }

        // POST: Inst/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Instrument inst)
        {
            try
            {
                // TODO: Add update logic here
                core.Repository.Update(inst);
                core.Repository.SaveAll();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inst/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inst/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
