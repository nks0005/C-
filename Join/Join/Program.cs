using System;
using System.Linq;

namespace Join
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile() {Name = "1", Height = 101 },
                new Profile() {Name="2", Height = 102 },
                new Profile() {Name="3",Height=103 },
                new Profile() {Name="4",Height=104 },
                new Profile() {Name = "5",Height=105 }
            };

            Product[] arrProduct =
            {
                new Product() {Title="1번",Star = "1" },
                new Product() {Title="2번",Star="2" },
                new Product() {Title ="3번",Star="3" },
                new Product() {Title="4번",Star="4" },
            };

            var listProfile =
                from profile in arrProfile
                join product in arrProduct on profile.Name equals product.Star
                select new
                {
                    Name = profile.Name,
                    Work = product.Star,
                    Height = profile.Height
                };

            Console.WriteLine("내부 조인 결과");
            foreach (var profile in listProfile)
                Console.WriteLine("이름 {0}, 작품 {1}, 키 {2}", profile.Name, profile.Work, profile.Height);

            listProfile =
                from profile in arrProfile
                join product in arrProduct on profile.Name equals product.Star into ps
                from product in ps.DefaultIfEmpty(new Product() { Title = "존재하지 않음." })
                select new
                {
                    Name = profile.Name,
                    Work = product.Star,
                    Height = profile.Height
                };

            Console.WriteLine("외부 조인 결과");
            foreach (var profile in listProfile)
                Console.WriteLine("이름 {0}, 작품 {1}, 키 {2}", profile.Name, profile.Work, profile.Height);
        }
    }
}