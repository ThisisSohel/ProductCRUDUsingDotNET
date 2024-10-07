using DataEdgePracticeExample.Database;
using DataEdgePracticeExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Threading.Tasks;
using System.Web.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;
using NHibernate.Linq;
=======
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;
using static System.Collections.Specialized.BitVector32;
>>>>>>> 21700f2598e03859bce24c8af740325630087921

namespace DataEdgePracticeExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISession _session;

        public ProductController()
        {
            _session = NHibernateHelper.OpenSession();
        }
<<<<<<< HEAD

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var products = await _session.Query<Product>().ToListAsync();
=======
        // GET: Product
        public ActionResult Index()
        {
            var products = _session.Query<Product>().ToList();
>>>>>>> 21700f2598e03859bce24c8af740325630087921
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<ActionResult> Create(Product model)
=======
        public ActionResult Create(Product model)
>>>>>>> 21700f2598e03859bce24c8af740325630087921
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _session.BeginTransaction())
                {
<<<<<<< HEAD
                    await _session.SaveAsync(model);
                    await transaction.CommitAsync();
=======
                    _session.Save(model);
                    transaction.Commit();
>>>>>>> 21700f2598e03859bce24c8af740325630087921
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

<<<<<<< HEAD
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
=======
        public ActionResult Edit(int? id)
>>>>>>> 21700f2598e03859bce24c8af740325630087921
        {
            if (id == null)
            {
                return View();
            }
<<<<<<< HEAD

            var product = await _session.GetAsync<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
            }
=======
            var product = _session.Get<Product>(id);
>>>>>>> 21700f2598e03859bce24c8af740325630087921
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<ActionResult> Edit(Product product)
        {
=======
        public ActionResult Edit(Product product)
        {

>>>>>>> 21700f2598e03859bce24c8af740325630087921
            if (ModelState.IsValid && product != null)
            {
                using (var transaction = _session.BeginTransaction())
                {
<<<<<<< HEAD
                    await _session.UpdateAsync(product);
                    await transaction.CommitAsync();
                    return RedirectToAction("Index");
                }
=======
                    _session.Update(product);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
>>>>>>> 21700f2598e03859bce24c8af740325630087921
            }
            return View(product);
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _session.GetAsync<Product>(id);
            if (product == null)
            {
                return HttpNotFound();
=======
        public ActionResult Delete(int id)
        {
            var product = _session.Get<Product>(id);

            if (product == null)
            {
                return View();
>>>>>>> 21700f2598e03859bce24c8af740325630087921
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
<<<<<<< HEAD
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
=======
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
>>>>>>> 21700f2598e03859bce24c8af740325630087921
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 21700f2598e03859bce24c8af740325630087921
