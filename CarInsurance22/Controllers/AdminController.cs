using CarInsurance22.Models;
using CarInsurance22.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance22.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin Where the stored data is at
        public ActionResult Index()
        {
            using (CarInsurance22Entities db = new CarInsurance22Entities())
            {
                var carinfo22 = db.CarInfo22.Where(x => x.removed == DateTime.MinValue).ToList();
                var carinfo22Vms = new List<CarInfo22Vm>();

                foreach (var _carinfo22 in carinfo22)
                {
                    var carinfo22vm = new CarInfo22Vm();
                    carinfo22vm.id = _carinfo22.id;
                    carinfo22vm.FirstName = _carinfo22.firstName;
                    carinfo22vm.LastName = _carinfo22.lastName;
                    carinfo22vm.EmailAddress = _carinfo22.emailAddress;
                    carinfo22vm.CarTotal = _carinfo22.carTotal;
                    carinfo22Vms.Add(carinfo22vm);

                }
                return View(carinfo22Vms);
            }

        }
        public ActionResult Unsubscribe(int id)
        {
            using (CarInsurance22Entities db = new CarInsurance22Entities())
            {
                var _carinfo22 = db.CarInfo22.Find(id);
                _carinfo22.removed = DateTime.Now;
                db.SaveChanges();
            }
           return RedirectToAction("Index");
           
        }
        
    }
  
 }
