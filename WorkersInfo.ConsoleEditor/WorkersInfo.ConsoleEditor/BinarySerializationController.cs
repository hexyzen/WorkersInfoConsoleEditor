using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    public class BinarySerializationController :
        GenericBinarySerializationController<IDataSet>
    {

        public void Load(IDataSet dataSet, string fileName)
        {
            IDataSet newDataSet = Load(fileName);
            if (newDataSet == null)
                return;
            foreach (var el in newDataSet.Seats)
            {
                dataSet.Seats.Add(el);
            }
            foreach (var el in newDataSet.Workers)
            {
                dataSet.Workers.Add(el);
            }
        }

    }
}
