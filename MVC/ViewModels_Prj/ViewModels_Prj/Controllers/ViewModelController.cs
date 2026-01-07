using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels_Prj.Models;

namespace ViewModels_Prj.Controllers
{
    public class ViewModelController : Controller
    {
        // GET: ViewModel
        public ActionResult Index()
        {
            return View();
        }

        //1. Accessing Viewmodel
        public ActionResult Employee_FullDetails()
        {
            Employee emp = new Employee()
            {
                EID = 101,
                Ename = "Harini",
                Salary = 50000,
                AddressId = 1
            };

            Address addr = new Address()
            {
                AddressId = 1,
                DoorNo = "4, ABC Villa",
                Street = "Gulli No. 420",
                City = "Dream City"
            };

            //create a view model object
            EmployeeAddress employeeAddress = new EmployeeAddress()
            {
                employee = emp,
                address = addr,
                PageTitle = "Employee Details"
            };
            return View(employeeAddress);
        }
    }
}