/*
 * 사용자가 매개 변수를 입력하지 않으면 현재 디렉토리에 대해, 매개 변수를 입력한 경우에는 입력한 디렉토리 경로에 대해 하위 디렉토리의 목록과 파일의 목록을 차례대로 출력합니다.
 * 하위 디렉토리 목록을 출력할 때는 이름과 속성을, 파일 목록을 출력할 때는 파일의 이름과 크기, 속성을 출력합니다.
  */
using System;
using System.Linq;
using System.IO;

namespace Dir
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory;
            if (args.Length < 1)
                directory = ".";
            else
                directory = args[0];

            Console.WriteLine("{0} directory info", directory);
            Console.WriteLine("- Directorys :");
            var directories = (from dir in Directory.GetDirectories(directory) // 하위 디렉토리 목록 조회
                               let info = new DirectoryInfo(dir) // let은 LINQ안에서 변수를 만드는 용도 ( var와 유사 )
                               select new
                               {
                                   Name = info.Name,
                                   Attributes = info.Attributes
                               }).ToList();

            foreach (var d in directories)
                Console.WriteLine("{0} : {1}", d.Name, d.Attributes);

            Console.WriteLine("- Files : ");
            var files = (from file in Directory.GetFiles(directory)
                         let info = new FileInfo(file)
                         select new
                         {
                             Name = info.Name,
                             FileSize = info.Length,
                             Attributes = info.Attributes
                         }).ToList();

            foreach (var f in files)
                Console.WriteLine("{0} : {1}, {2}", f.Name, f.FileSize, f.Attributes);
        }
    }
}           