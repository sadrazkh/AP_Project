using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Modals.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public string ProductPhotoAdress { get; set; }
        public int Store { get; set; }
        public string Explanations { get; set; }
        public string ManuFacturer { get; set; }
        public string Category { get; set; }

    }
}
