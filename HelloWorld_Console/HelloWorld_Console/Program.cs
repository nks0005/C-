using System;
/*
 * Using System;
 *  > System : 숫자, 텍스트와 같은 데이터를 다룰 수 있는 기본적인 데이터 처리 클래스를 비롯하여 C# 코드가 기본적으로 필요로 하는 클래스를 담고 있는 네임스페이스.
 *  > using System : 컴파일러에게 System 네임스페이스 안에 있는 클래스를 사용하겠다고 컴파일러에게 알리는 역할을 함.
 */

namespace HelloWorld
/*
 * > Namespace : 성격이나 하는 일이 비슷한 클래스, 구조체, 인터페이스, 델리게이트, 열거 형식 등을 하나의 이름 아래 묶는 일을 합니다. 
 *                      Ex. .NET 프레임워크의 System.IO 네임스페이스에 파일 입출력을 다루는 각종 클래스, 구조체, 델리게이트, 열거 형식.  system.Printing 네임스페이스에는 인쇄에 관련된 일을 하는 클래스 등이 소속되어 있음.
 *                      
 *  > 다른 네임스페이스에서 현재 HelloWorld의 HelloWorld 클래스를 사용하려면 using HelloWorld; 라는 문장을 이용해서 HelloWorld 네임스페이스를 참조하거나 using HelloWorld.HelloWorld처럼 클래스가 소속되어 있는 네임스페이스와 클래스의 이름을 붙여야 합니다.
 */
{
    class HelloWorld
    /*
     * class HelloWorld : HelloWorld라는 클래스를 생성 ( C++와 비슷 ) 
     * 클래스는 C# 프로그램을 구성하는 기본 단위로서 데이터와 데이터를 처리하는 기능(Method)으로 이루어집니다.
     */
    {
        // 프로그램 실행이 되는 곳
        static void Main(string[] args) 
        // static void Main(string[] args)는 메소드이며, Main 메소드는 프로그램의 진입점(Entry Point)으로서, 프로그램이 시작되면 실행되고, 이 메소드가 종료되면 프로그램도 역시 종료됩니다.
        {
            Console.WriteLine("Hello, World!");
            // "Hello, World!" 문자열을 한줄에 출력후, '\n'를 마지막에 출력하여 다음 줄로 커서를 이동.
        }
    }
}

/*
 * CLR(Common Language Runtime) : C#으로 만든 프로그램이 실행되는 환경.
 */