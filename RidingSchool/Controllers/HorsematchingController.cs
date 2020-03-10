using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RidingSchool.Models;
using Newtonsoft.Json;

//### Den här kan raderas(?)

namespace RidingSchool.Controllers
{
    public class HorsematchingController : Controller
    {
        /*
        [HttpGet]
        //startar med Index-sidan
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Horse(IFormCollection info)
        {
            //Gör att konstruktorn körs
            PersonData rider = new PersonData();

            //läser in det som samlats i IFormCollection
            //namnges som i input-delen
            rider.Name = info["Name"];
            rider.Weight = Convert.ToInt32(info["Weight"]);
            rider.Length = Convert.ToInt32(info["Length"]);
            rider.Date = Convert.ToDateTime(info["Date"]);
            rider.calculateHorseMatch();

            string sessionstring = JsonConvert.SerializeObject(rider);
            HttpContext.Session.SetString("somesession", sessionstring);

            return View(rider); 
        }*/
    }
}
