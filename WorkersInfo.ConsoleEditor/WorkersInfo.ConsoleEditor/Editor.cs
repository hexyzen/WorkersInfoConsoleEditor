using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    public partial class Editor
    {

        private DataContext dataContext;

        IEnumerable<Seat> sortingSeats;// Сортування
        IEnumerable<Worker> sortingWorkers;// Сортування

        public Editor(DataContext dataContext)
        {
            this.dataContext = dataContext;
            sortingSeats = dataContext.Seats;  // Сортування
            sortingWorkers = dataContext.Workers;// Сортування
            IniCommandsInfo();
        }

        private CommandInfo[] commandsInfo;

        private void IniCommandsInfo()
        {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("Вийти", null),
                new CommandInfo("Створити тестові дані",  dataContext.CreateTestingData),
                new CommandInfo("Додати запис посади", AddSeat),
                new CommandInfo("Додати запис працівника", AddWorker),
                new CommandInfo("Зберегти", dataContext.Save),  // приклад
                new CommandInfo("Завантажити", dataContext.Load),   
                new CommandInfo("Видалити запис посади", RemoveSeat),
                new CommandInfo("Видалити запис працівника", RemoveWorker),
                new CommandInfo("Видалити усі записи", dataContext.Clear),
                new CommandInfo("Сортувати посади за назвою", SortSeatsByName),
                new CommandInfo("Сортувати працівників за ПІБ", SortWorkersByName),
                new CommandInfo("Сортувати працівників за посадою", SortWorkersBySeat),
                new CommandInfo("Сортувати працівників за віком", SortWorkersByAge),
                new CommandInfo("Сортувати працівників за стажем", SortWorkersByExpa),
            };
        }
        private void ShowCommandsMenu()
        {
            Console.WriteLine("  Список команд меню:");
            for (int i = 0; i < commandsInfo.Length; i++)
            {
                Console.WriteLine("\t{0,2} - {1}",
                    i, commandsInfo[i].name);
            }
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                OutData();
                Console.WriteLine();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null)
                {
                    return;
                }
                command();
            }
        }

        

        private Command EnterCommand()
        {
            Console.WriteLine();
            //int? number = Entering.EnterInt32(
            //    "Введіть номер команди:");
            //return commandsInfo[number].command;
            int? number = Entering.EnterInt32("Номер команди меню" +
                "");
            if (number == null) return null;
            return number >= 0 && number <= commandsInfo.Length ? commandsInfo[(int)number].command : EnterCommand();
        }

    }
}
