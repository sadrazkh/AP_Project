using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Func.Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace AP_Project.Back_End.Func.Persons
    {
        public class Person : Modals.Persons.Person
        {
            public Person(string Us, string Pas, string _FullName, string _Email, string _PhoneNumber)
            {
                bool Creat = false;
                Password = Security.Hash_SHA256.CreatHash256(Pas);
                AccessLevel = 1;

                using (var db = new Modals.Context())
                {
                    var res = db.Persons.Where(i => i.UserName == Us && i.Email == _Email && i.FullName == _FullName && i.PhoneNumber == _PhoneNumber).FirstOrDefault();
                    if (res == null)
                    {
                        base.UserName = Us;
                        base.FullName = _FullName;

                        if (System.Text.RegularExpressions.Regex.IsMatch(_PhoneNumber, @"(\+98|0)?9\d{9}"))
                        {
                            base.PhoneNumber = _PhoneNumber;
                        }
                        else
                        {
                            throw new Exceptions.InfoFormatException("فرمت شماره همراه وارد شده نادرست است");
                        }

                        if (System.Text.RegularExpressions.Regex.IsMatch(_Email, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                        {
                            base.Email = _Email;
                        }
                        else
                        {
                            throw new Exceptions.InfoFormatException("فرمت ایمیل وارد شده نادرست است");
                        }

                        Creat = true;
                    }
                    else
                    {
                        throw new Exceptions.InfoExistException("اطلاعات بالا تکراری می باشند");
                    }

                }

                if (Creat)
                {
                    try
                    {
                        using (var db = new Modals.Context())
                        {
                            db.Persons.Add(new Modals.Persons.Person { UserName = Us, Password = Security.Hash_SHA256.CreatHash256(Pas), FullName = _FullName, PhoneNumber = _PhoneNumber, Email = _Email, AccessLevel = 1, Cart = null });
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
            public static bool PersonLogin(string Us, string Pas)
            {
                try
                {
                    using (var db = new Modals.Context())
                    {
                        var res = db.Persons.Where(i => i.UserName == Us || i.Email == Us)
                            .Where(i => i.Password == Security.Hash_SHA256.CreatHash256(Pas)).FirstOrDefault();
                        if(res != null)
                        {
                            MainRoot.SetRoot(res.UserName, res.FullName, res.AccessLevel, res.Email, res.PhoneNumber, res.Cart);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            public  void ChangePersonPass(string OldPass, string NewPass)
            {
                using (var db = new Modals.Context())
                {
                    string Us = base.UserName;
                    var res = db.Persons.Where(i => i.UserName == Us)
                        .Where(i => (bool)(i.Password == Security.Hash_SHA256.CreatHash256(OldPass))).FirstOrDefault();
                    if (res != null)
                    {
                        base.Password = Security.Hash_SHA256.CreatHash256(NewPass);
                    }
                    else
                    {
                        throw new Exception("Old Password Is Wrong!");
                    }
                    db.SaveChanges();
                }
            }
            public  void ChangePersonalInfo(string NewEmail, string NewFullName, string NewPhoneNumber)
            {
                string Us = base.UserName;
                using (var db = new Modals.Context())
                {
                    var res = db.Persons.Where(i => i.UserName == Us).FirstOrDefault();
                    if (NewFullName != null)
                    {
                        base.FullName = NewFullName;
                        res.FullName = NewFullName;
                    }
                    if (NewEmail != null)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(NewEmail, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                        {
                            base.Email = NewEmail;
                            res.Email = NewEmail;
                        }
                        else
                        {
                            throw new Exceptions.InfoFormatException("فرمت ایمیل وارد شده نادرست است");
                        }
                    }
                    if (NewPhoneNumber != null)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(NewPhoneNumber, @"(\+98|0)?9\d{9}"))
                        {
                            base.PhoneNumber = NewPhoneNumber;
                            res.PhoneNumber = NewPhoneNumber;
                        }
                        else
                        {
                            throw new Exceptions.InfoFormatException("فرمت شماره وارد شده نادرست است");
                        }
                    }
                    db.SaveChanges();

                }
            }
            public static bool LogOut()
            {
                return true;
            }

            public static void PersonGen(int len,int RamControler = 20)
            {
                Modals.Persons.Person[] Pr = new Modals.Persons.Person[RamControler];
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < RamControler; j++)
                    {
                        Pr[j] =new Modals.Persons.Person { FullName = RandomGen.GetFulNameDefault(), Password = RandomGen.GetPasswordDefault(8) , AccessLevel = 1 }; 
                    }
                    for (int j = 0; j < RamControler; j++)
                    {
                        try
                        {
                            ConectionToDb.AddNewPeronNoLimited(Pr, RamControler);
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
            }

            public static bool PasswordRecovery()
            {
                try
                {

                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
                
            }
        }
    }
}
