using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using RidingSchool.Models;

namespace RidingSchool.Models
{
    public class PersonData
    {
        [Required]
        [Display (Name="Ditt namn:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Din vikt i kilo:")]
        public int Weight { get; set; }

        [Required]
        [Display(Name = "Din längd i centimeter:")]
        public int Length { get; set; }

        //string pga ska visas som text
        public string RateTodaysRidinglesson { get; set; }
        public string HorseName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Välj datum för din ridlektion:")]
        public DateTime Date { get; set; }

        public PersonData()
        {
        }

        public void calculateHorseMatch()
        {
            if ((Weight < 40) && (Length < 150))
            {
                HorseName = "Mulle";
            }
            else if ((Weight >= 40) && (Weight < 60) && (Length < 170))
            {
                HorseName = "Svarta Hingsten";
            }
            else if ((Weight >= 60) && (Weight < 90) && (Length < 200))
            {
                HorseName = "Jolly Jumper";
            }
            else
            {
                HorseName = "Brunte";
            }
            
        } 
    }
}
