using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Func
{
    public class ConectionToDb
    {
        public static void AddNewPeronNoLimited(Modals.Persons.Person[] Pr , int PrLen)
        {
            using (var db = new Modals.Context())
            {
                for (int i = 0; i < PrLen; i++)
                {
                    db.Persons.Add(Pr[i]);
                }
                db.SaveChanges();
            }
        }
        public static void AddNewProduct(string Name, int store, string ProductPhotoAdress, string Explanations, string Category, string ManuFacturer, int PB)
        {
            using (var db = new Modals.Context())
            {
                db.Products.Add(new Modals.Products.Product { ProductName = Name, ProductPhotoAdress = ProductPhotoAdress,
                    Explanations = Explanations, Category = Category, ManuFacturer = ManuFacturer, Store = store, ProductBarcode = PB });
                db.SaveChanges();
            }
        }

        public static void ChangeProductStore(int NewStore,int PB)
        {
            using (var db = new Modals.Context())
            {
                var res = db.Products.Where(i => i.ProductBarcode == PB).FirstOrDefault();
                res.Store = NewStore;
                db.SaveChanges();
            }
        }
    }
}
