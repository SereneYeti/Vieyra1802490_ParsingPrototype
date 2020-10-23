using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Vieyra1802490_ParsingPrototype
{
    public class Items
    {
        public int key;
        public string name;
        public string discription;

        public override string ToString()
        {
            return name + ", " + discription + ", " + key;
        }
    }

}
