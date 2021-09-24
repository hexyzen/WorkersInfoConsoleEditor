﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersInfo.ConsoleEditor
{
    public delegate void Command();
    public struct CommandInfo
    {
        public string name;
        public Command command;

        public CommandInfo(string name, Command command)
        {
            this.name = name;
            this.command = command;
        }
    }
}
