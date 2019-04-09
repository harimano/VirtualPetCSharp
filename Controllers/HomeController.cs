using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualPetDojoDatchi.Models;
using Microsoft.AspNetCore.Http;

namespace VirtualPetDojoDatchi.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? meal = HttpContext.Session.GetInt32("Meal");
            string message = HttpContext.Session.GetString("Message");
            Pet doggy = new Pet();

            if (happiness is null)
            {
                System.Console.WriteLine("Rubber baby buggy bumpers");
                HttpContext.Session.SetInt32("Happiness", doggy.Happiness);
                HttpContext.Session.SetInt32("Fullness", doggy.Fullness);
                HttpContext.Session.SetInt32("Energy", doggy.Energy);
                HttpContext.Session.SetInt32("Meal", doggy.Meal);
                HttpContext.Session.SetString("Message", doggy.Message);
            }   
            else
            {
                doggy.Happiness = (int)happiness;
                doggy.Meal = (int)meal;
                doggy.Energy = (int)energy;
                doggy.Fullness = (int)fullness;
                doggy.Message = message;
                System.Console.WriteLine("-----------------");
                System.Console.WriteLine(doggy.Happiness);
                System.Console.WriteLine(doggy.Meal);
                System.Console.WriteLine(doggy.Energy);
                System.Console.WriteLine(doggy.Fullness);
                System.Console.WriteLine(doggy.Message);

            }     
        
            // string Message = HttpContext.Session.GetString("Message");
            return View("Index", doggy);
        }

        [Route("feed")]
        [HttpGet]
        public IActionResult FeedPet()
        {
            var random = new Random();

            if(HttpContext.Session.GetInt32("Meal")!= null)
            {
                var IncreaseVal = random.Next(5,10);
                HttpContext.Session.SetInt32("Fullness",(int)HttpContext.Session.GetInt32("Fullness")+IncreaseVal);
                HttpContext.Session.SetInt32("Meal" ,(int)HttpContext.Session.GetInt32("Meal")-1);
                HttpContext.Session.SetString("Message","Your Dog Just Ate a Meal +"+IncreaseVal+" Fullness");
                System.Console.WriteLine(HttpContext.Session.GetString("Message"));
                
            }
            else
            {
                HttpContext.Session.SetString("Message","No Meals Left Dawg");
                System.Console.WriteLine(HttpContext.Session.GetString("Message"));
            }
            System.Console.WriteLine(">>>>>>>>>>>>>>>>");
            System.Console.WriteLine(HttpContext.Session.GetInt32("Happiness"));
            System.Console.WriteLine(HttpContext.Session.GetInt32("Fullness"));
            System.Console.WriteLine(HttpContext.Session.GetInt32("Meal"));
            System.Console.WriteLine(HttpContext.Session.GetString("Message"));
            System.Console.WriteLine(HttpContext.Session.GetInt32("Energy"));
            return RedirectToAction("Index");
        }

        [Route("play")]
        [HttpGet]
        public IActionResult PlayPet()
        {             
            var random = new Random();

            if(HttpContext.Session.GetInt32("Energy")!=null)
            {
                var IncreaseVal = random.Next(5,10);
                int tempHappy = (int)HttpContext.Session.GetInt32("Happiness");
                int tempEnergy = (int)HttpContext.Session.GetInt32("Energy"); 
                HttpContext.Session.SetInt32("Happiness", tempHappy+IncreaseVal);
                HttpContext.Session.SetInt32("Energy",tempEnergy -5);
                HttpContext.Session.SetString("Message","Your Dog Gained "+IncreaseVal+"Happiness and Lost 5 Energy");
            }
            else 
            {
                HttpContext.Session.SetString("Message","No Energy Dawg!!");
            }
            System.Console.WriteLine(">>>>>>>>>>>>>>>>");
            System.Console.WriteLine(HttpContext.Session.GetInt32("Happiness"));
            System.Console.WriteLine(HttpContext.Session.GetInt32("Fullness")); 
            System.Console.WriteLine(HttpContext.Session.GetInt32("Meal"));
            System.Console.WriteLine(HttpContext.Session.GetString("Message"));
            System.Console.WriteLine(HttpContext.Session.GetInt32("Energy"));         
            return RedirectToAction("Index");
        }

        [Route("work")]
        [HttpGet]
        public IActionResult WorkPet()
        {  
            var random = new Random();
            if(HttpContext.Session.GetInt32("Energy")!=null)
            {
                var IncreaseVal = random.Next(1,3);
                int tempMeal = (int)HttpContext.Session.GetInt32("Meal");
                int tempEnergy = (int)HttpContext.Session.GetInt32("Energy"); 
                HttpContext.Session.SetInt32("Meal", tempMeal+IncreaseVal);
                HttpContext.Session.SetInt32("Energy",tempEnergy -5);
                HttpContext.Session.SetString("Message","Your Dog Gained "+IncreaseVal+"Meals by working and Lost 5 Energy");
            }
            else 
            {
                HttpContext.Session.SetString("Message","No Energy Dawg!!");
            }
            return RedirectToAction("Index");     
        }

        [Route("sleep")]
        [HttpGet]
        public IActionResult SleepPet()
        {  
            var random = new Random();
            if(HttpContext.Session.GetInt32("Energy")>=0)
            {
                int tempFullness = (int)HttpContext.Session.GetInt32("Fullness");
                int tempEnergy = (int)HttpContext.Session.GetInt32("Energy"); 
                int tempHappiness = (int)HttpContext.Session.GetInt32("Happiness"); 

                HttpContext.Session.SetInt32("Energy", tempEnergy+15);
                HttpContext.Session.SetInt32("Fullness",tempFullness -5);
                HttpContext.Session.SetInt32("Happiness",tempHappiness -5);
                HttpContext.Session.SetString("Message","Your Dog Gained "+15+" Energy by Sleeping and Lost 5 Fullness and Happiness");
            }
            else 
            {
                HttpContext.Session.SetString("Message","You're Dog doesn't want to sleep Dawg!!");
            }
            return RedirectToAction("Index");     
        }
    }
}
