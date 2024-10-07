using DataEdgePracticeExample.Database;
using DataEdgePracticeExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;
using static System.Collections.Specialized.BitVector32;

namespace DataEdgePracticeExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISession _session;

        public ProductController()
        {
            _session = NHibernateHelper.OpenSession();
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = _session.Query<Product>().ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.Save(model);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var product = _session.Get<Product>(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid && product != null)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.Update(product);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _session.Get<Product>(id);

            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var product = _session.Get<Product>(id);
            if (product == null)
            {
                return View();
            }
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(product);
                transaction.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Details(int id)
        {
            var product = _session.Get<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}