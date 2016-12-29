﻿/*
 * 매개 변수로 입력받은 경로에 새 디렉토리나 파일을 만듭니다.
 * 사용자가 입력한 경로에 이미 만들어져 있는 파일이나 디렉토리가 존재한다면 해당 파일이나 디렉토리의 최종 수정 시간만을 갱신합니다.
 */
using System;
using System.IO;

namespace Touch
{
    class Program
    {
        static void OnWrongPathType(string type)
        {
            Console.WriteLine("{0} is wrong type", type);
            return;
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage : Touch.exe <Path> [Type:File/Directory]");
                return;
            }

            string path = args[0];
            string type = "File";
            if (args.Length > 1)
                type = args[1];

            if (File.Exists(path) || Directory.Exists(path))
            {
                if (type == "File")
                    File.SetLastWriteTime(path, DateTime.Now);
                else if (type == "Directory")
                    Directory.SetLastWriteTime(path, DateTime.Now);
                else
                {
                    OnWrongPathType(path);
                    return;
                }
                Console.WriteLine("Update {0} {1}", path, type);
            }
            else
            {
                if (type == "File")
                    File.Create(path).Close();
                else if (type == "Directory")
                    Directory.CreateDirectory(path);
                else
                {
                    OnWrongPathType(path);
                    return;
                }

                Console.WriteLine("Created {0} {1}", path, type);
            }
        }
    }
}