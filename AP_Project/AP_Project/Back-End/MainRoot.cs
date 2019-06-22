using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End
{
    public class MainRoot
    {
        public static void SetRoot(Back_End.Modals.Persons.Person ob)
        {
            UserName = ob.UserName;
            FullName = ob.FullName;
            AccesAccessLevel = ob.AccessLevel;
            Email = ob.Email;
            PhoneNumber = ob.PhoneNumber;
            Cart = ob.Cart;
        }
        public static void SetRoot(string _UserName,string _FullName,short? _AccesAccessLevel,string _Email,string _PhoneNumber,List<Modals.Products.Product> _Cart)
        {
            UserName = _UserName;
            FullName = _FullName;
            AccesAccessLevel = _AccesAccessLevel;
            Email = _Email;
            PhoneNumber = _PhoneNumber;
            Cart = _Cart;
        }

        public static string UserName  { get; set; }
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
