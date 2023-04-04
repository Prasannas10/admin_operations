using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using adminoperation.Models;
using System.Data.Entity;

namespace adminoperation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            // Get all products from the database
            var products = db.Products.ToList();

            // Pass the list of products to the view
            return View(products);
        }

        //...
       

            // GET: Product/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Product/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Name, Price, Description,Quantity")] Product product)
            {
                if (ModelState.IsValid)
                {
                    // Add the new product to the database
                    db.Products.Add(product);
                    db.SaveChanges();

                    // Redirect to the product list page
                    return RedirectToAction("Index");
                }

                // If the model state is not valid, return to the create page
                return View(product);
            }

            // GET: Product/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                // Find the product with the specified id
                var product = db.Products.Find(id);

                if (product == null)
                {
                    return HttpNotFound();
                }

                // Pass the product to the view
                return View(product);
            }

            // POST: Product/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id, Name, Price, Description,Quantity")] Product product)
            {
                if (ModelState.IsValid)
                {
                    // Update the product in the database
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();

                    // Redirect to the product list page
                    return RedirectToAction("Index");
                }

                // If the model state is not valid, return to the edit page
                return View(product);
            }

            // GET: Product/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                // Find the product with the specified id
                var product = db.Products.Find(id);

                if (product == null)
                {
                    return HttpNotFound();
                }

                // Pass the product to the view
                return View(product);
            }

            // POST: Product/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                // Find the product with the specified id
                var product = db.Products.Find(id);

                // Remove the product from the database
                db.Products.Remove(product);
                db.SaveChanges();

                // Redirect to the product list page
                return RedirectToAction("Index");
            }

            private ApplicationDbContext db = new ApplicationDbContext();
        


       
    }
}