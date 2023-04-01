using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Element
    {
        public string Value { get; set; }
        public int Key { get; set; }

        public Element Next { get; set; }

        public Element(int key, string value, Element next)
        {
            Key = key;
            Value = value;
            Next = next;
        }

    }
}
