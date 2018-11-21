using CarInsurance22.Models;
using CarInsurance22.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance22.Controllers
{
    public class HomeController : Controller
    {
       public decimal carTotal;
        //The logic for if the customer filled out the questionare right

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CarInfo22(string firstName, string lastName, string emailAddress, string carModel, string carMake, int tickets, string dui, string coverage, DateTime dateOfBirth, int carYear = 0)
        {

            if (dateOfBirth == null) { dateOfBirth = DateTime.MinValue; }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(carModel)
                || string.IsNullOrEmpty(carMake) || (carYear == 0) || DateTime.Equals(dateOfBirth, DateTime.MinValue) || string.IsNullOrEmpty(dui) || string.IsNullOrEmpty(coverage))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                CarInsurance22Entities db = new CarInsurance22Entities();
                CarInfo22 carinfo22 = new CarInfo22();   
               
                    carTotal = 50;
                    carinfo22.firstName = firstName;
                    carinfo22.lastName = lastName;
                    carinfo22.emailAddress = emailAddress;
                    carinfo22.carModel = carModel;
                    carinfo22.carMake = carMake;
                    carinfo22.tickets = tickets;
                    carinfo22.dui = dui;
                    carinfo22.coverage = coverage;
                    carinfo22.carYear = carYear;
                    carinfo22.dateOfBirth = dateOfBirth;
                    carinfo22.carTotal = CalcQuote(carModel, carMake, carYear, tickets, dui, coverage, dateOfBirth);
                    db.CarInfo22.Add(carinfo22);
                    db.SaveChanges();
                

                return View("Success",db.CarInfo22.OrderByDescending(x => x.id).Take(1).ToList());
            }
        }
            public decimal CalcQuote(string CarModel, string CarMake, int CarYear, int Tickets, string Dui, string Coverage, DateTime DateOfBirth)
        {
            // math here

            decimal carTotal = 50;
            {

                 if (DateTime.Now.Year - DateOfBirth.Year < 25)

                {

                    carTotal = carTotal + 25;

                }

                 if (DateTime.Now.Year- DateOfBirth.Year < 18)

                {

                   carTotal = carTotal + 100;

                }

                if (DateTime.Now.Year - DateOfBirth.Year > 100)
                {
                    carTotal = carTotal + 25;
                }
                 if (CarYear < 2000)
               {
             carTotal = carTotal + 25;
                }

                if (CarYear > 2015)
                {
                    carTotal = carTotal + 25;
                }

                if (CarMake.ToLower() == "porsche")
                {
                    carTotal = carTotal + 25;
                }
                if (CarMake.ToLower() == "porsche" && CarModel.ToLower() == "911 carrera")
                {
                carTotal = carTotal + 25;

                }

                if (Tickets > 4)
                {
                carTotal = carTotal + (Tickets * 10);
                }

                if (Dui.ToLower() == "yes")
                {
                carTotal = carTotal + (Decimal.Multiply(carTotal, .25M));

                }
                    if (Coverage.ToLower() == "full")
                {
                    carTotal = carTotal + (Decimal.Multiply(carTotal, .25M));
                    Convert.ToString(carTotal);
                }
                return  (carTotal);
            }
        }
    }

   
    
    
}

   