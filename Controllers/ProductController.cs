using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventory.Repository;
using System.Collections.Generic;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonalDataController

        ProductStockRepository ObjRepository;

        public ProductController()
        {
            ObjRepository = new ProductStockRepository();
        }

        public ActionResult ListallProductData()
        {
            return View("Select", ObjRepository.Select());
        }

        public ActionResult ListallCustomerData()
        {
            return View("Customer", ObjRepository.SelectCustomerDetails());
        }




        public IActionResult ProductDropdown()
        {
            // Retrieve the list of products and create a SelectList.
            var products = ObjRepository.Select();
            var productList = new SelectList(products, "ProductId", "ProductName");

            // Set the productList in the ViewBag.
            ViewBag.ProductList = productList;

            return View("SalesList");
        }


        // GET: PersonalDataController/Create
        public ActionResult InsertRecord()
        {
            return View("Insert", new ProductDetailsModels());
        }

        // POST: PersonalDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDetailsModels data)
        {
            try
            {
                ObjRepository.InsertProductData(data);
                return RedirectToAction(nameof(ListallProductData));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("Edit", res);
        }

        // POST: PersonalDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductDetailsModels Reg)
        {
            try
            {
                Reg.Productid = id;
                ObjRepository.ubdate(Reg);
                return RedirectToAction(nameof(ListallProductData));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditSales(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("EditSales", res);
        }

        // POST: PersonalDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSales(int id, ProductDetailsModels Reg)
        {
            try
            {
                Reg.Productid = id;
                ObjRepository.ubdateSales(Reg);
                return RedirectToAction(nameof(ListallProductData));
            }
            catch
            {
                return View();
            }
        }

      

        // GET: Registration/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("Delete", res);
        }

        // POST: Registration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Productid)
        {
            try
            {
                ObjRepository.delete(Productid);
                return RedirectToAction(nameof(ListallProductData));
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("Details", res);
        }

    }
}
