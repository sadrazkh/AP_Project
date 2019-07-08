using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Project.Back_End.Func
{
    public class RandomGen
    {
        private static string AlphanumericCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890?></!@#$%^&*()|}{][~:;-_=+`.,";
        private static string[] Name = new string[]
        {"Oliver","George","Harry","Noah","Jack","Charlie","Leo","Jacob","Freddie","Alfie","Archie","Theo","Oscar","Arthur","Thomas","Logan","Henry","Joshua","James","William","Max"
            ,"Isaac","Lucas","Ethan","Teddy","Finley","Mason","Harrison","Hunter","Alexander","Daniel","Joseph","Tommy","Arlo","Reggie","Edward","Jaxon","Adam","Sebastian","Rory","Riley"
            ,"Dylan","Elijah","Carter","Albie","Louie","Toby","Benjamin","Reuben","Jude","Samuel","Harley","Luca","Frankie","Ronnie","Jenson","Hugo","Jake","David","Theodore","Roman","Bobby"
            ,"Alex","Caleb","Ezra","Ollie","Finn","Jackson","Zachary","Jayden","Harvey","Albert","Lewis","Blake","Stanley","Elliot","Grayson","Liam","Louis","Matthew","Elliott","Tyler","Luke"
            ,"Michael","Gabriel","Ryan","Dexter","Kai","Jesse","Leon","Nathan","Ellis","Connor","Jamie","Rowan","Sonny","Dominic","Eli","Aaron","Jasper"};
        private static Random NewSeed = new Random();
        public static string GetPasswordDefault(int length)
        {
            Random Ra = new Random();
            string res = "";
            Random rand = new Random(NewSeed.Next() + Ra.Next());
            for (int i = 0; i < length; i++)
            {
                res += string.Format("{0}", AlphanumericCharacters[rand.Next(0, 91)]);
            }
            return res;
        }
        public static string GetPassworDefault(int length, int seed)
        {
            Random Ra = new Random();
            string res = "";
            Random rand = new Random(seed + Ra.Next());
            for (int i = 0; i < length; i++)
            {
                res += string.Format("{0}", AlphanumericCharacters[rand.Next(0, 91)]);
            }
            return res;
        }
        public static string GetFulNameDefault()
        {
            Random Ra = new Random();
            string res = "";
            Random rand = new Random(NewSeed.Next() + Ra.Next());
            for (int i = 0; i < 2; i++)
            {
                res += string.Format("{0}", Name[rand.Next(0, 99)]);
                if (i == 0)
                {
                    res += " ";
                }
            }
            return res;
        }

    }
}
