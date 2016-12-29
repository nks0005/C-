using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializingCollection
{
    [Serializable]
    class NameCard
    {
        public NameCard(string Name, string Phone, int Age)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Age = Age;
        }

        public string Name;
        public string Phone;
        public int Age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            List<NameCard> list = new List<NameCard>();
            list.Add(new NameCard("1", "010-111-1111", 1));
            list.Add(new NameCard("2", "000-123-4567", 2));
            list.Add(new NameCard("3", "020-456-7890", 3));

            serializer.Serialize(ws, list);
            ws.Close();

            Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            List<NameCard> list2 = (List<NameCard>)deserializer.Deserialize(rs);
            rs.Close();

            foreach(var nc in list2)
            {
                Console.WriteLine("Name : {0}, Phone : {1}, Age : {2}", nc.Name, nc.Phone, nc.Age);
            }
        }
    }
}