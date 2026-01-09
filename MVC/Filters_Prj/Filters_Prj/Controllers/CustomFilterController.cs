using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters_Prj.CustomFilters;

namespace Filters_Prj.Controllers
{
    public class CustomFilterController : Controller
    {
        // GET: CustomFilter
        public string Index()
        {
             return "Index Action of Custom Controller Invoked";           
        }

        //2. testing the custom filter trackexecutions
        [TrackExecutions]
        public string Welcome()
        {
            throw new Exception("Exception Occurred.");
        }
    }
}