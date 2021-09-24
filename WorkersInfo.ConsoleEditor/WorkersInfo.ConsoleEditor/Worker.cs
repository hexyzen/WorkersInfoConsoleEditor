using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    [Serializable]
    public class Worker : Entity
    {
        //public int Id { get; set; }
        //public double? expa;
        //public Nullable<decimal> expa;


        public string name { get; set; }
        public decimal age { get; set; }
        public decimal? expa { get; set; }

        public Seat seat { get; set; }

        protected override string ToMembersString()
        {
            return string.Format(
                "{0,7} {1}, Посада: {2},  Вік: {3};  Досвід: {4} р.",
                Id, name, seat.name, age, expa); //seat
        }

        public Worker(string name, Seat seat,
                    decimal age, decimal? expa)
        {
            this.name = name;
            this.seat = seat;
            this.age = age;
            this.expa = expa;
        }

        public Worker() { }

        public Worker(string name, Seat seat, decimal age)
            : this(name, seat, age, null) { }

    }
}
