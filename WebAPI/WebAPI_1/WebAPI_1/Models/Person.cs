using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_1.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonJob { get; set; }
        public string Gender { get; set; }
    }
}