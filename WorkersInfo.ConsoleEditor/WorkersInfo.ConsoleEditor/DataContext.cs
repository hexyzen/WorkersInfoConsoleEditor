using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    [Serializable]
    public class DataContext : FileDataContext, IDataSet
    {
        public DataContext()
        {
            FileName = "WorkersInfo.cibd";
        }
        

        private readonly List<Seat> seats = new List<Seat>();
        private readonly List<Worker> workers = new List<Worker>();

        public ICollection<Worker> Workers
        {
            get { return workers; }
        }

        public ICollection<Seat> Seats
        {
            get { return seats; }
        }

        [NonSerialized]
        private BinarySerializationController binarySerializationController =
            new BinarySerializationController();


        public void Save()
        {
            binarySerializationController.Save(this, Path);
        }

        public void Load()
        {
            binarySerializationController.Load(this, Path);
        }

        public override string ToString()
        {
            return string.Concat("Інформація про об'єкти ПО \"Працівники\"\n",
                Workers.ToLineList("Працівники"),
                Seats.ToLineList("Посади"));
        }

        public void Clear()
        {
            Workers.Clear();
            Seats.Clear();
        }

        public void CreateTestingData()
        {
            CreateSeats();
            CreateWorkers();
        }

        //private void CreateSeats()
        //{
        //    Seats.Add(new Seat("Інженер") { Id = 1 });
        //    Seats.Add(new Seat("Кібербезпека") { Id = 2 });
        //    Seats.Add(new Seat("Оператор") { Id = 3 });
        //}
        private void CreateSeats()
        {
            Seats.Add(new Seat("HR", null, 1500) { Id = 1 });
            Seats.Add(new Seat("Інженер", Seats.FirstOrDefault(e => e.name == "Dev")) { Id = 2 });
            Seats.Add(new Seat("Кібербезпека", Seats.FirstOrDefault(e => e.name == "Security"), 1000) { Id = 3 });
            Seats.Add(new Seat("Оператор", Seats.FirstOrDefault(e => e.name == "Hardware")) { Id = 4 });
            Seats.Add(new Seat("Team Leader", null) { Id = 5 });
        }

        private void CreateWorkers()
        {
            Workers.Add(new Worker("John Shepard",
               Seats.First(e => e.name == "Інженер"), 23, 5)
            {
                Id = 1,
            });
            Workers.Add(new Worker("Ейден Пирс", 
             Seats.First(e => e.name == "Кібербезпека"), 23, null)
            {
                Id = 2,
               
            });
            Workers.Add(new Worker("Юстас",
               Seats.First(e => e.name == "Оператор"), 32)
            {
                Id = 3,
                expa = null
            });
            Workers.Add(new Worker("Костюк Роман",
                Seats.First(e => e.name == "Team Leader"), 22)
            {   
              expa = 4,
              Id = 4,
            });
        }
    }
}