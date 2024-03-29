﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
            public static int len {get;  set; }
            public static int RamControler {get;  set; }

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
            public  static void ChangePersonalInfo(string user,string NewEmail, string NewFullName, string NewPhoneNumber)
            {
                using (var db = new Modals.Context())
                {
                    var res = db.Persons.Where(i => i.UserName == user).FirstOrDefault();
                    if (NewFullName != null)
                    {
                        res.FullName = NewFullName;
                    }
                    if (NewEmail != null)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(NewEmail, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
                        {
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
                MainRoot.SetRoot(null);
                return true;
            }
            public static void PersonGen()
            {

                Modals.Persons.Person[] Pr = new Modals.Persons.Person[RamControler];
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < RamControler; j++)
                    {
                        Pr[j] = new Modals.Persons.Person { FullName = RandomGen.GetFulNameDefault(), Password = RandomGen.GetPasswordDefault(8), AccessLevel = 1 };
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
            public static void PersonGen(int Len , int ramControler  )
            {
                len = Len;
                RamControler = ramControler;

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
            public static void PersonGenThread(int Len = 1000,int ramControler = 20)
            {
                len = Len;
                RamControler = ramControler;
                Thread Th = new Thread(PersonGen);
                Th.Start();
            }
            public static bool PasswordRecovery(string username)
            {
                try
                {
                    using (var db = new Modals.Context())
                    {
                        var res = db.Persons.Where(i => i.UserName == username).FirstOrDefault();
                        string Rec = RandomGen.GetPasswordDefault(8);
                        res.RecoveryCode = Rec;
                        Security.MailSender.MailSend(res.Email, Rec);
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
                
            }
            public static bool PasswordRecovery(string username,string RecoveryCode,string NewPassword)
            {
                try
                {
                    using (var db = new Modals.Context())
                    {
                        var res = db.Persons.Where(i => i.UserName == username).FirstOrDefault();
                        if (res.RecoveryCode == RecoveryCode)
                        {
                            string Pass = Security.Hash_SHA256.CreatHash256(NewPassword);
                            res.Password = Pass;
                            db.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Your code incorect!");
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }

            }
            public static void PersonGene(int count)
            {
                Modals.Persons.Person Pr = new Modals.Persons.Person();
                using (var db = new Modals.Context())
                {
                    for (int i = 0; i < count; i++)
                    {
                        Pr = new Modals.Persons.Person { FullName = RandomGen.GetFulNameDefault(), Password = RandomGen.GetPasswordDefault(8), AccessLevel = 1 };
                        db.Persons.Add(Pr);
                    }
                    db.SaveChanges();
                }

            }
        }
    }
}
