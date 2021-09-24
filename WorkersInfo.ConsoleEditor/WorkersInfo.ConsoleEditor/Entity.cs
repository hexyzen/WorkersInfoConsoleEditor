using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    [Serializable]
    public abstract class Entity
    {
        public int Id { get; set; }

        public sealed override string ToString()
        {
            return string.Format($"{Id,7} {ToMembersString()}");
        }

        protected abstract string ToMembersString();
    }
}
