﻿using FC.Entities;
using FC.Repositories;
using SIMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMS.Controllers
{
    public class ProductController : Controller
    {

        readonly ProductRepository _productDb = new ProductRepository();
        readonly SupplierRepository _supplierDb = new SupplierRepository();
        #region Action
        // GET: Product
        public ActionResult Index()
        {
            var objProduct = new FC_Product();
            GetProductListModel();
            return View(objProduct);
        }

        [HttpPost]
        public ActionResult SaveProduct(FC_Product model)
        {
            _productDb.SaveChanges(model);
            return PartialView("_ProductList", GetProductListModel());
        }

        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            var Product = _productDb.Get(productId);
            return PartialView("_ProductForm", Product);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _productDb.Get(productId);
            product.IsDeleted = true;
            _productDb.SaveChanges(product);
            return PartialView("_ProductList", GetProductListModel());
        }

        #endregion

        #region Methods
        public ProductViewModels GetProductListModel()
        {
            var lstProduct = _productDb.GetAll();
            var viewmodel = new ProductViewModels { productList = lstProduct.ToList() };
            ViewBag.ProductList = viewmodel;

            var lstSupplier = _supplierDb.GetAll();
            ViewBag.SupplierList = viewmodel;

            return viewmodel;
        }
        #endregion
    }
}