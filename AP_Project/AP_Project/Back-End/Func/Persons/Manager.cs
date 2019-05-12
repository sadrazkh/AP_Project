using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Func.Persons
{
    public class Manager : Modals.Persons.Manager
    {
        public void ChangeAccessLevel(short NewAccessLevel,string UserName)
        {
            try
            {
                using (var db = new Modals.Context())
                {
                    var res = db.Persons.Where(i => i.UserName == UserName).FirstOrDefault();
                    res.AccessLevel = NewAccessLevel;
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
