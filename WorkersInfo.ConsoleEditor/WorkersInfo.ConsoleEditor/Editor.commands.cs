using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    partial class Editor
    {

        private void OutData()
        {
            OutSeatsData();
            OutWorkersData();
        }

        private void OutSeatsData()
        {
            Console.WriteLine($"Список посад:\n{"Id",-5}{"Назва",-15}{"Плата $",-5}");
            foreach (var obj in dataContext.Seats)
            {
                Console.WriteLine("{0,-5} {1,-15} {2, -5}",
                 obj.Id, obj.name, obj.cash);
            }
        }

        private void OutWorkersData()
        {
            Console.WriteLine($"Список працівників \n{"Id",-5} {"ПІБ",-15} {"Посада",-15} {"Вік",2} {"Стаж",-4}");
            foreach (var obj in sortingWorkers)
            {
                string seatName = obj.seat.name;
                Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,2} {4,2}",
                    obj.Id, obj.name, obj.seat.name, obj.age, obj.expa);
            }
        }

        public void AddSeat()
        {
            Seat inst = new Seat();
            inst.name = Entering.EnterString("Назва посади:",15);
            inst.Id = dataContext.Seats.Count > 0 ? dataContext.Seats.Select(e => e.Id).Max() + 1 : 1;
            inst.cash = Entering.EnterDecimalOrNull("Заробітня плата:");
            dataContext.Seats.Add(inst);
        }

        public void AddWorker()
        {
            Worker inst = new Worker();
            inst.name = Entering.EnterString("ПІБ працівника:",15);
            inst.seat = SelectSeat();
            inst.age = Entering.EnterDecimalOrNull("Вік:");
            inst.expa = Entering.EnterNullableDecimal("Стаж:");
            //inst.Id = dataContext.Workers.Select(e => e.Id).Max() + 1;
            inst.Id = dataContext.Workers.Count > 0 ? dataContext.Workers.Select(e => e.Id).Max() + 1 : 1;
            dataContext.Workers.Add(inst);
        }

        private Seat SelectSeat()
        {
            string seatName = Entering.EnterString("Посади:");
            try
            {
              return dataContext.Seats.First(e => e.name == seatName);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Не було знайдено посади у списку");
                SelectSeat();
            }
            return null; // Не добереться
        }


        public void RemoveSeat()
        {
            int? id = Entering.EnterInt32("Введіть ID посади:");
            Seat inst = dataContext.Seats.FirstOrDefault(e => e.Id == id);
            dataContext.Seats.Remove(inst);
        }

        public void RemoveWorker()
        {
            int? id = Entering.EnterInt32("Введіть ID працівника:");
            Worker inst = dataContext.Workers.FirstOrDefault(e => e.Id == id);
            dataContext.Workers.Remove(inst);
        }


        private void SortSeatsByName()
        {
            sortingSeats = sortingSeats.OrderBy(e => e.name);
        }

        private void SortWorkersByName()
        {
            sortingWorkers = sortingWorkers.OrderBy(e => e.name);
        }

        private void SortWorkersBySeat()
        {
            sortingWorkers = sortingWorkers.OrderBy(e => e.seat.name);
        }

        private void SortWorkersByAge()
        {
            sortingWorkers = sortingWorkers.OrderBy(e => e.age);
        }

        private void SortWorkersByExpa()
        {
            sortingWorkers = sortingWorkers.OrderBy(e => e.expa);
        }

    }
}
