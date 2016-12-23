using System;

namespace PropertiesInInterface
{
    interface INamedValue
    {
        string Name
        {
            get; set;
        }

        string Value
        {
            get; set;
        }
    }

    class NamedValue : INamedValue
    {
        public string Name
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue() { Name = "이름", Value = "안형빈" };
            NamedValue height = new NamedValue() { Name = "키", Value = "200Cm" };
            NamedValue weight = new NamedValue() { Name = "몸무게", Value = "1000Kg" };

            Console.WriteLine("{0} : {1}", name.Name, name.Value);
            Console.WriteLine("{0} : {1}", height.Name, height.Value);
            Console.WriteLine("{0} : {1}", weight.Name, weight.Value);
        }
    }
}