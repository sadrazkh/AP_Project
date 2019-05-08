using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Func.Persons
{
    public class Person : Modals.Persons.Person
    {
        Person(string Us, string Pas, string _FullName, string _Email, string _PhoneNumber)
        {
            bool Creat = false;
            Password = Security.Hash_SHA256.CreatHash256(Pas);
            AccessLevel = 1;

            using (var db = new Modals.Context())
            {
                var res = db.Persons.Where(i => i.UserName == Us && i.Email == _Email && i.FullName == _FullName && i.PhoneNumber == _PhoneNumber).FirstOrDefault();
                if(res == null)
                {
                    UserName = Us;
                    FullName = _FullName;

                    if (System.Text.RegularExpressions.Regex.IsMatch(_PhoneNumber, @"(\+98|0)?9\d{9}"))
                    {
                        PhoneNumber = _PhoneNumber;
                    }
                    else
                    {
                        throw new FormatException("فرمت شماره همراه وارد شده نادرست است");
                    }

                    if (System.Text.RegularExpressions.Regex.IsMatch(_Email, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                    {
                        Email = _Email;
                    }
                    else
                    {
                        throw new FormatException("فرمت ایمیل وارد شده نادرست است");
                    }

                    Creat = true;
                }
                else
                {
                    throw new Exception("اطلاعات بالا تکراری می باشند");
                }
            }

            if(Creat)
            {
                try
                {
                    using (var db = new Modals.Context())
                    {
                        db.Persons.Add(new Modals.Persons.Person { UserName = Us, Password = Security.Hash_SHA256.CreatHash256(Pas), FullName = _FullName, PhoneNumber = _PhoneNumber, Email = _Email, AccessLevel = 1, Cart = null });
                        db.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }
        Person(string Us,string Pas)
        {
            try
            {
                using (var db = new Modals.Context())
                {
                    var res = db.Persons.Where(i => i.UserName == Us || i.Email == Us)
                        .Where(i => i.Password == Security.Hash_SHA256.CreatHash256(Pas)).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
