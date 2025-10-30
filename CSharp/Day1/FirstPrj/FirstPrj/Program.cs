using System;


namespace FirstPrj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to CSharp..");

            //trying to call other functions of the same class

            //1. non static instance function need an object of the class
            //2. static functions does not need any object

            Program program = new Program();
            int z = program.add(5, 6);  // calling an instance function / method
            Console.WriteLine(z);


            //creatimg object 2
            Program program1 = new Program();
            Console.WriteLine(program1.add(10, 6));
            
            Greet();   //calling a static function of the same class 

            //calling the static function of another class

            NewClass.Message("Infinite");

            //calling an instance method of another class
            NewClass nc = new NewClass();
            Console.WriteLine(nc.Hello("Kanishka")); 

            //calling instance function of another class in another file
            
            DisplayTypes dt = new DisplayTypes();
            dt.Display();
            Console.ReadLine();  //holds the screen and waits for input
        }

        int add(int x, int y)  //callee
        {
            Console.WriteLine("hi reached add function");
            return x + y;
            Console.WriteLine("Going out of add");  //unreachable code
        }

        static void Greet()
        {
            Console.WriteLine( "Hi");
        }
    }
    class NewClass
    {
        public static void Message(string name)
        {
            Console.WriteLine(name);
        }

        public string Hello(string name)  // instance method
        {
            return "Hi" + name;
        }
    }
    
}
