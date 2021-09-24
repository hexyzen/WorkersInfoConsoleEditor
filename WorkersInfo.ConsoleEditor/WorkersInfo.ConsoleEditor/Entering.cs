using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    public static class Entering
    {
        public static string format = "{0,20} ";

        public static int? EnterInt32(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            if (s=="")
            {
                return null;
            }
              else { 
                    try
                    {
                      int value = int.Parse(s);
                      return value;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неправильний формат даних");
                        
                        return EnterInt32(prompt);
                        //привязані до попередньої функції,
                    }
                //return null;
              } 
        }

        public static string EnterString(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            return s.Trim();
        }

        public static string EnterString(string prompt, int maxsymbols = 15)
        {  
           
            string s;
                
            while (true)
            {          
                 s = EnterString(prompt); 
                 if (s.Length <= maxsymbols)
                 {
                      return s;
                 }
                 else Console.WriteLine("Велика кількість даних");
            }
        }

        public static decimal EnterDecimalOrNull(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            return (decimal)((s == "") ? (decimal?)null : Convert.ToDecimal(s));
        }

        public static decimal? EnterNullableDecimal(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write("{0}: ", prompt);
                    string s = Console.ReadLine();
                    return (s == "") ? (decimal?)null : Convert.ToDecimal(s);
            
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Введено неправильне значення");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }


    }
}
