using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsurance22.Models
{
        public partial class Car22
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }
            public DateTime DateofBirth { get; set; }
            public string CarMake { get; set; }
            public string CarModel { get; set; }
            public int CarYear { get; set; }
            public int Tickets { get; set; }
            public string Dui { get; set; }
            public string Coverage { get; set; }
            public DateTime Removed { get; set; }
            public decimal CarTotal { get; set; }
     }
 }

