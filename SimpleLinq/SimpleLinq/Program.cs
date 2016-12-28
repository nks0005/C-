using System;
using System.Linq;

namespace SimpleLinq
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile() {Name="1",Height=1 },
                new Profile() {Name ="2", Height=2 },
                new Profile() {Name="3",Height=3 },
                new Profile() {Name="4",Height=4 },
                new Profile() {Name="5",Height=5 }
            };

            var Profiles = from profile in arrProfile
                           where profile.Height < 3
                           orderby profile.Height
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height
                           };

            foreach (var profile in Profiles)
                Console.WriteLine("{0}, {1}", profile.Name, profile.InchHeight);
        }
    }
}