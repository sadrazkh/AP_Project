using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End
{
    public sealed class MainRoot
    {
        public static string UserName { get; set; }
        public static string FullName { get; set; }
        public static short? AccesAccessLevel { get; set; }
        public static string Email { get; set; }
        public static string PhoneNumber { get; set; }
        public static List<Modals.Products.Product> Cart { get; set; }
        


        public static void LogOut()
        {
            UserName = null;
            FullName = null;
            AccesAccessLevel = null;
            Email = null;
            PhoneNumber = null;
            Cart = null;
            
        }

    }
}
