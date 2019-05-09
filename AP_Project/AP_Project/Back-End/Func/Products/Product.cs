﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Func.Products
{
    public class Product : Modals.Products.Product
    {
        Product(string Name,int store,string ProductPhotoAdress,string Explanations,string Category,string ManuFacturer,int PB)
        {
            base.ProductBarcode = PB;
            base.ProductName = Name;
            base.ProductPhotoAdress = ProductPhotoAdress;
            base.Store = store;
            base.Explanations = Explanations;
            base.Category = Category;
            base.ManuFacturer = ManuFacturer;

            using (var db = new Modals.Context())
            {
                db.Products.Add(this);
                db.SaveChanges();
            }
        }

        public void ChangeProductStore(int NewStore)
        {
            using (var db = new Modals.Context())
            {
                int PB = base.ProductBarcode;
                var res = db.Products.Where(i => i.ProductBarcode == PB).FirstOrDefault();
                if(res != null)
                {
                    if (NewStore >= 0)
                    {
                        res.Store = NewStore;
                    }
                    db.SaveChanges();
                }
            }
        }

        public Modals.Products.Product SelectProduct()
        {
            try
            {
                using (var db = new Modals.Context())
                {
                    string ProductName = base.ProductName;
                    var res = db.Products.Where(i => i.ProductName == ProductName).FirstOrDefault();
                    if (res != null)
                    {
                        ChangeProductStore(base.Store - 1);
                    }
                    return res;
                }
            }
            catch
            {
                throw new Exception("Product Not Found");
            }

        }
    }
}