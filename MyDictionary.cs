using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class MyDictionary
    {
        private Element[] arr;
        private int Capasity ;
        private int CapasityLimit;
        private int Filling;



        public MyDictionary()
        {
            arr = new Element[3];
            Capasity = arr.Length;
            CapasityLimit = Capasity * 4 / 5;
            Filling = 0;
        }

        public void Add(string value)
        {
            Add(value, arr);
        }

        private void Add(string value, Element[] array)
        {
            int hashCode = GethashCode(value);
            int index = GetHash(hashCode);

            var found  = FindInList(array[index], value);

            if (array[index]==null )
            { 
                Filling++; 
            }
            

            if (found.element == null)
            {
                Element _el = new Element(hashCode, value, array[index]);
                array[index] = _el;
            }

            if (Filling> CapasityLimit)
            { 
                ReHesh(); 
            }
        }

        private void ReHesh()
        {
            Element[] arrCopy;

            arrCopy = new Element[Capasity*2+1];
            Capasity = arrCopy.Length;
            CapasityLimit = Capasity * 4 / 5;
            Filling = 0;

            foreach (Element element in arr)
            {
                if (element.Value==null) 
                    continue;
                Add(element.Value, arrCopy);

                Element next = element.Next;
                while (next!=null && next.Value!=null)
                {
                    Add(next.Value, arrCopy);
                    next = element.Next;
                }
            }
            arr = arrCopy;
        }

        public Element Get(string value)
        {
            int hashCode = GethashCode(value);
            int index = GetHash(hashCode);

            var found = FindInList(arr[index], value);
            
            return found.element;
        }


        public void Delete(string value)
        {
            int hashCode = GethashCode(value);
            int index = GetHash(hashCode);
            var found = FindInList(arr[index], value);
            Element x = found.element;

            if (x!=null && found.previous != null)
            {
                found.previous.Next = found.element.Next;
            }
            else if(x != null && found.previous == null)
            {
                arr[index] = x.Next;
            }
        }


        private (Element element, Element previous) FindInList(Element x, string value)
        {
            Element previous = null;
            while (x != null)
            {
                if (x.Value == value) { return (x, previous); }
                previous = x;
                x = x.Next;
            }

            return (null,null);
        }

        private int GetHash(int hashCode)
        {
            return hashCode % arr.Length;
        }

        private int GethashCode(string value)
        {

            int key = 0;
            foreach (char c in value)
            {
                key = key + (int)c;
            }

            return key;
        }
    }
}
