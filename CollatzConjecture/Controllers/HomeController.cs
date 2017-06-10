using CollatzConjecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CollatzConjecture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortOrder, string evenExp, string oddExp)
        {
            ViewBag.EvenExp = string.IsNullOrEmpty(evenExp) ? 2 : int.Parse(evenExp);
            ViewBag.OddExp = string.IsNullOrEmpty(oddExp) ? 3 : int.Parse(oddExp);

            IList<StartingNumber> numbers = new List<StartingNumber>();
            for (int i = 1; i < 100; i++)
            {
                numbers.Add(new StartingNumber(i, ViewBag.EvenExp, ViewBag.OddExp));
            }

            ViewBag.TheNumSortParm = string.IsNullOrEmpty(sortOrder) ? "thenum_desc" : "";
            ViewBag.NumStepsSortParm = sortOrder == "numsteps" ? "numsteps_desc" : "numsteps";

            IOrderedEnumerable<StartingNumber> orderedNumbers;
            switch (sortOrder)
            {
                case "thenum_desc":
                    orderedNumbers = numbers.OrderByDescending(n => n.TheNum);
                    break;
                case "numsteps":
                    orderedNumbers = numbers.OrderBy(n => n.NumSteps);
                    break;
                case "numsteps_desc":
                    orderedNumbers = numbers.OrderByDescending(n => n.NumSteps);
                    break;
                default:
                    orderedNumbers = numbers.OrderBy(s => s.TheNum);
                    break;
            }

            return View(orderedNumbers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}