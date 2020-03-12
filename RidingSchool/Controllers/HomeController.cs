using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using RidingSchool.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
//För listan
using Microsoft.AspNetCore.Mvc.Rendering;




namespace RidingSchool.Controllers
{
    public class HomeController : Controller
    {

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
            rider.HorseName = info["HorseName"];
            rider.Name = info["Name"];
            rider.Weight = Convert.ToInt32(info["Weight"]);
            rider.Length = Convert.ToInt32(info["Length"]);
            rider.Date = Convert.ToDateTime(info["Date"]);
            rider.calculateHorseMatch();

            string sessionstring = JsonConvert.SerializeObject(rider);
            HttpContext.Session.SetString("somesession", sessionstring);

            return View(rider);
        }

        [HttpGet]
        public IActionResult Review()
        {
            List<SelectListItem> reviewList = new List<SelectListItem>();

            reviewList.Add(new SelectListItem { Text = "Dåligt", Value = "0" });
            reviewList.Add(new SelectListItem { Text = "Mittemellan", Value = "1" });
            reviewList.Add(new SelectListItem { Text = "Bra", Value = "2" });

            return View(reviewList);
        }

        [HttpPost]
        public IActionResult Result(IFormCollection content)
        {
            PersonData rider = new PersonData();
            string sessionstring = HttpContext.Session.GetString("somesession");
            rider = JsonConvert.DeserializeObject<PersonData>(sessionstring);
            int rateLesson = Convert.ToInt32(content["RateTodaysRidinglesson"]);


            //Listan igen, för att få ut texten istället för value-siffran
            List<SelectListItem> reviewList = new List<SelectListItem>();

            reviewList.Add(new SelectListItem { Text = "dåligt :(", Value = "0" });
            reviewList.Add(new SelectListItem { Text = "mittemellanbra.", Value = "1" });
            reviewList.Add(new SelectListItem { Text = "bra :)", Value = "2" });


            rider.RateTodaysRidinglesson = reviewList[rateLesson].Text;

            ViewBag.text = "Tips: Sitt lite rakare i ryggen nästa gång!";

            return View(rider);
        }
    }
}
