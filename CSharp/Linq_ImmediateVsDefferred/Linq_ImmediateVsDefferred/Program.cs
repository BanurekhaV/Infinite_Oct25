using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_ImmediateVsDefferred
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp = new List<Employee>
            {
                new Employee{Id=1, Name="Deepalakshmi", Salary=30000},
                new Employee{Id=2, Name="Humera", Salary=42000},
                new Employee{Id=3, Name="Nagamani", Salary=54000},
            };

            //query construction/declaration
            var e = emp.Where(x => x.Salary < 35000).Select(y => y.Name).ToList(); //immediate
            var e1 = emp.Where(x => x.Salary < 35000).Select(y => y.Name); // deferred
            
            
            //creating another employee instance after the construction of linq query
            emp.Add(new Employee { Id = 4, Name = "Manikanta Sai", Salary = 28000 });

            foreach (var ename in e) 
            {
                Console.WriteLine(ename);
            }
            Console.ReadLine();
        }
    }
}
