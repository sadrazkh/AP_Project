using System;
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
            ConectionToDb.AddNewProduct(Name, store, ProductPhotoAdress, Explanations, Category, ManuFacturer, PB);
        }

        public void ChangeProductStore(int NewStore)
        {
            ConectionToDb.ChangeProductStore(NewStore,this.ProductBarcode);
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
