using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Modals.Persons
{
    public class Person
    {
        public int PersonId { get; set; }
        public short? AccessLevel { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Products.Product> Cart { get; set; }
    }
}
