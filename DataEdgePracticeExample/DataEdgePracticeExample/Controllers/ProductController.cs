using DataEdgePracticeExample.Database;
using DataEdgePracticeExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;
using NHibernate.Linq;

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
        public async Task<ActionResult> Index()
        {
            var products = await _session.Query<Product>().ToListAsync();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    await _session.SaveAsync(model);
                    await transaction.CommitAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var product = await _session.GetAsync<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            if (ModelState.IsValid && product != null)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    await _session.UpdateAsync(product);
                    await transaction.CommitAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _session.GetAsync<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var product = await _session.GetAsync<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            using (var transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(product);
                await transaction.CommitAsync();
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            var product = await _session.GetAsync<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}
