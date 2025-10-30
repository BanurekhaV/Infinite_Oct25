using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstPrj
{
    internal class DisplayTypes
    {
        //let us check various display options 

        public void Display()
        {
            string fname, lname;
            Console.WriteLine("Enter your FirstName :");
            fname = Console.ReadLine();
            Console.WriteLine("Enter your LastName :");
            lname = Console.ReadLine();

            Console.WriteLine("Your FirstName is : " + fname + " and last name is : " + lname);  //concatenation

            Console.WriteLine("Your FirstName is : {0} and last name is {1} ", fname ,lname); //placeholder

            Console.WriteLine($"Your FirstName is : {fname} and last name is : {lname} "); //string interpolation
        }
    }
}
