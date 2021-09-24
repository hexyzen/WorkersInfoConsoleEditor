using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    class Program
    {
        //static DataContext dataContext;
        static Editor editor;

        static void Main(string[] args)
        {
            Console.Title = "CountriesInfo.FinalProject (Костюк Р. С.)";
            Settings.SetConsoleParam();
            Console.WriteLine("Програми з використанням ООП (Фінальний проект)");

            DataContext dataContext = new DataContext();
            editor = new Editor(dataContext);
            editor.Run();

            Console.ReadKey(true);
        }

    }
}
