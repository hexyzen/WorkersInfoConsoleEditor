using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    public interface IDataSet
    {
        ICollection<Seat> Seats { get; }
        ICollection<Worker> Workers { get; }
    }
}
