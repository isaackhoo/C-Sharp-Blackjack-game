using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace testCsharp.Model
{
    public class Player
    {
        public Guid _id { get; private set; }
        public string Name { get; private set; }
        public IPAddress Ip { get; private set; }

        // constructor
        public Player(string name, IPAddress ip)
        {
            _id = Guid.NewGuid();
            Name = name;
            Ip = ip;
        }
    }
}
