using System;
using System.Linq;

namespace GroupBy
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
                new Profile() {Name="1",Height = 100 },
                new Profile() {Name="2", Height=101 },
                new Profile() {Name="3", Height=103 },
                new Profile() {Name="4",Height=104 },
                new Profile() {Name="5",Height=105 }
            };

            var listProfile = from profile in arrProfile
                              orderby profile.Height
                              group profile by profile.Height < 103 into g
                              select new { GroupKey = g.Key, Profiles = g };

            foreach (var Group in listProfile)
            {
                Console.WriteLine("- 175cm 미만? : {0}", Group.GroupKey);
                
                foreach (var profile in Group.Profiles)
                {
                    Console.WriteLine("{0}, {1}", profile.Name, profile.Height);
                }
            }
        }
    }
}