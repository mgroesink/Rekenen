using Microsoft.AspNetCore.Mvc;
using Rekenen.Models;

namespace Rekenen.Controllers
{
    public class CalculateController : Controller
    {
        public IActionResult Index()
        {
            return View(new Calculation());
        }

        [HttpPost]
        public IActionResult Index(string option, string category , string level, Calculation calculation,string answer = "") 
        { 
            ViewBag.answer = answer;
            if(option == "Start")
            {
                switch(category)
                {
                    case "Plus":
                        calculation = new Calculation(level,'+');
                        break;
                    case "Min":
                        calculation = new Calculation(level , '-');
                        break;
                    case "Keer":
                        calculation = new Calculation(level , 'x');
                        break;
                    default:
                        calculation = null;
                        break;
                }
                ViewBag.answer = "";
            }
            if(option == "Check")
            {
                if(calculation.Result == int.Parse(answer))
                {
                    ViewBag.resultaat = "Jouw antwoord is goed.";
                    
                }
                else
                {
                    ViewBag.resultaat = $"Jouw antwoord is helaas niet goed. Het juiste antwoord was {calculation.Result}.";
                    if(calculation.Operator == '+')
                    {
                        ViewBag.resultaat += "<br/>Kijk <a target='blank' href='https://www.beterrekenen.nl/website/index.php?pag=213'>hier</a> voor uitleg";
                    }
                    else if(calculation.Operator == '-')
                    {
                        ViewBag.resultaat += "<br/>Kijk <a target='blank' href='https://www.beterrekenen.nl/website/index.php?pag=214'>hier</a> voor uitleg";

                    }
                    else if (calculation.Operator == 'x')
                    {
                        ViewBag.resultaat += "<br/>Kijk <a target='blank' href='https://www.beterrekenen.nl/website/index.php?pag=215'>hier</a> voor uitleg";
                    }
                }
            }
            ViewBag.som = calculation;

            return View(calculation);
        }
    }
}
