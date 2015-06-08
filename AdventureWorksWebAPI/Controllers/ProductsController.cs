using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventureWorksWebAPI;
using AdventureWorksWebAPI.Models;

namespace AdventureWorksWebAPI.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorks2012Entities db = new AdventureWorks2012Entities();


        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductModel).Include(p => p.ProductProductPhotoes)
                                      //.Where(p => (p.ProductProductPhotoes.FirstOrDefault().ProductPhotoID > 1))
                                      .OrderBy(p => p.Name);
            return View(products.ToList());
        }


        // GET: Products/Category/T
        public ActionResult Category(string category)
        {
            var result = "Products";
            var products = db.Products.Include(p => p.ProductSubcategory).Include(p => p.ProductProductPhotoes)
                                      .OrderBy(p => p.Name);

            if (category == "M" || category == "R" || category == "T")
            {
                result = (category == "M") ? "Mountain Bikes" : (category == "R") ? "Road Bikes" : "Tour Bikes";
                products = db.Products.Include(p => p.ProductSubcategory).Include(p => p.ProductProductPhotoes)
                                      .Where(p => (p.ProductLine.Equals(category) && p.ProductSubcategory.ProductCategory.Name == "Bikes"))
                                      .OrderBy(p => p.Name);
            }
            else if (category == "A")
            {
                result = "Accessories";
                products = db.Products.Include(p => p.ProductSubcategory).Include(p => p.ProductProductPhotoes)
                                      .Where(p => (p.ProductSubcategory.ProductCategory.Name == "Accessories"))
                                      .OrderBy(p => p.Name);
            }
            else if (category == "C")
            {
                result = "Clothing";
                products = db.Products.Include(p => p.ProductSubcategory).Include(p => p.ProductProductPhotoes)
                                      .Where(p => (p.ProductSubcategory.ProductCategory.Name == "Clothing"))
                                      .OrderBy(p => p.Name);
            }
            else if (category == "P")
            {
                result = "Parts";
                products = db.Products.Include(p => p.ProductSubcategory).Include(p => p.ProductProductPhotoes)
                                      .Where(p => (p.ProductSubcategory.ProductCategory.Name == "Components"))
                                      .OrderBy(p => p.Name);
            }

            return View(new ProductsVM { Category = result, Products = products.ToList() });
        }


        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name");
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name");
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name");
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name");
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductSubcategoryID = new SelectList(db.ProductSubcategories, "ProductSubcategoryID", "Name", product.ProductSubcategoryID);
            ViewBag.SizeUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.SizeUnitMeasureCode);
            ViewBag.WeightUnitMeasureCode = new SelectList(db.UnitMeasures, "UnitMeasureCode", "Name", product.WeightUnitMeasureCode);
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
