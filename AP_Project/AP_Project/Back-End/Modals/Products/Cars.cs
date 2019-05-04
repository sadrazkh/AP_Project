using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Modals.Products
{
    public class Cars : Products.Product
    {
        public int CarId { get; set; }
        public string CarTag { get; set; }
        public int CarNumber { get; set; }
        public int FuelTank { get; set; }

    }
}
