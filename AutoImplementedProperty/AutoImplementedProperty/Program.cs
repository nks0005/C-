using System;

namespace AutoImplementedProperty
{
    class BirthdayInfo
    {
        public string Name
        {
            get; set;
        }
        public DateTime Birthday
        {
            get; set;
        }
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo();
            birth.Name = "형빈";
            birth.Birthday = new DateTime(1997, 10, 19);

            Console.WriteLine("Name : {0}", birth.Name);
            Console.WriteLine("Birthday : {0}", birth.Birthday.ToShortDateString());
            Console.WriteLine("Age : {0}", birth.Age);
        }
    }
}