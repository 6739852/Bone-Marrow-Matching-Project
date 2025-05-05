using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neomy
{
    class Validation
    {
        //בדיקה אם הטקסט בעברית
        public static bool IsHebrew(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if( (s[i] < 'א' || s[i] > 'ת') && (s[i] != ' '))
                    return false;
            }

            return true;
        }
        //בדיקה אם הטקסט באנגלית
        public static bool IsEnglish(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] < 'a' || s[i] > 'z') && (s[i] != ' '))
                    return false;
            }

            return true;
        }
        //בדיקת תקינות מייל
        public static bool IsMail(string s)
        {
            int t = 0, c = 0;
            for (int i = 0; i < s.Length; i++)
            {//בדיקה שאין אותיות בעברית
                if ((s[i] < 'א' || s[i] >= 'ת') && (s[i] == ' '))
                    return false;
                if (s[i] == '@')
                {
                    c++;
                    if (c > 1)
                        return false;
                }

            }
            if (!s.Contains("@"))//@ בדיקה אם יש 
                return false;
            if (s.IndexOf('@') == 0)// לא ראשון @ בדיקה  
                return false;
            for (int i = s.IndexOf('@'); i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    if (t == 0)
                    {
                        t++;
                        if (s.IndexOf("@") + 1 >= i)//בדיקה שיש אחרי שטרודל נקודה אבל לא ברצף
                            return false;
                        if (i == s.Length - 1)//בדיקה שהנקודה לא אחרונה
                            return false;
                    }
                }
            }
            if (t == 0)//בדיקה אם יש נקודה
                return false;
            return true;

        }

        //בדיקה אם הטקסט מספר  
        public static bool IsNum(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }

            return true;
        }

        //בדיקת תקינות טלפון  
        public static bool IsTel(string s)
        {

            if (s == "")
                return true;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 9)
                return false;
            return true;
        }
        //בדיקת תקינות פלפון  
        public static bool IsPelepon(string s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                    return false;
            }
            if (s.IndexOf('0') != 0 || s.Length != 10)
                return false;
            return true;
        }

        //בדיקת תקינות ת.ז
        public static bool CheckId(string d)
        {
            if (!Validation.IsNum(d))
                return false;
            while (d.Length < 9)
            {
                d = "0" + d;
            }


            int s = 0, t;
            for (int i = 0; i < d.Length; i++)
            {
                if (i % 2 == 0)// הראשון זוגי להכפיל ב1  
                {
                    s += Convert.ToInt32(d[i].ToString());
                }
                if (i % 2 != 0)
                {
                    t = Convert.ToInt32(d[i].ToString()) * 2;
                    if (t < 10)
                        s += t;
                    else
                        s += t % 10 + t / 10;

                }
            }

            if (s % 10 == 0)
                return true;
            return false;

        }

        public static int GetNumDay(string dayname)
        {
            string[] days = new string[] { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i] == dayname)
                    return i + 1;
            }
            return -1;
        }
        public static string GetNameDay(int numDay)
        {
            string[] days = new string[] { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי" };
            return days[numDay];
        }
        public static bool IsNumDouble(string s)
        {
            int mone = 0;
            if (!IsNum(s[0].ToString()))
                return false;
            if (!IsNum(s[s.Length-1].ToString()))
                return false;
            for (int i = 1; i < s.Length-1; i++)
            {
                if (!IsNum(s[i].ToString()))
                    if (s[i] != '.')
                        return false;
                    else
                        mone++;
            }
            if (mone > 1)
                return false;
            return true;

        }

        public static bool IsHebrewChar(char c)
        {
            string hebrewTav = "אבגדהוזחטיכךלמםנןסעפףצץקרשת";
            if (hebrewTav.IndexOf(c) == -1 && c != '\b' && c != ' ')
                return true;
            else
                return false;
        }

        public static bool IsNumberChar(char c)
        {
            if ((c >= '0' && c <= '9') || c == '\b')
                return false;
            return true;
        }

        public static bool IsNumberDouble(char c)
        {
            if ((c >= '0' && c <= '9') || c == '\b' || c=='.')
                return false;
            return true;
        }

        public static bool IsNumberPhone(char c)
        {
            if ((c >= '0' && c <= '9') || c == '\b' || c == '-')
                return false;
            return true;
        }

    }
}
