using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    [Serializable]
    public class Seat : Entity
    {

        public string name { get; set; }

        public Seat Parent { get; set; }

        public decimal? cash { get; set; }

        public Seat(string name, Seat parent, decimal? cash)
        {
            this.name = name;
            Parent = parent;
            this.cash = cash;
        }

        public Seat(string name, Seat parent) : this(name, parent, null) { }

        public Seat() { }

        protected override string ToMembersString()
        {
            return string.Format("{0}{1} {2}$",
                name, Parent == null ? "" : Parent.name, cash);
        }
    }
}
