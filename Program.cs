using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {


            var stringCollection = new MyDictionary();
            stringCollection.Add("Передали 2");
            stringCollection.Add("Передали 3");
            stringCollection.Add("Передали 4");
            stringCollection.Add("Передали 5");


            Element x=stringCollection.Get("Передали 2");
            if (x!=null) { Console.WriteLine($" value={x.Value},  key={x.Key}"); }


            stringCollection.Delete("Передали 4");


        }
    }
}
