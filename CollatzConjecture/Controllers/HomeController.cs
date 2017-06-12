using CollatzConjecture.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CollatzConjecture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortOrder, string evenExp, string currentEvenExp, string oddExp, string currentOddExp, int? page)
        {
            //UNDONE: allow for actual expression input instead of ints only
            //UNDONE: use floats instead of ints for expression

            //get expressions
            if (evenExp != null)
            {
                page = 1;
            }
            else
            {
                evenExp = currentEvenExp ?? "2";
            }
            ViewBag.CurrentEvenExp = evenExp;

            if (oddExp != null)
            {
                page = 1;
            }
            else
            {
                oddExp = currentOddExp ?? "3";
            }
            ViewBag.CurrentOddExp = oddExp;

            //generate data
            IList<StartingNumber> numbers = new List<StartingNumber>();
            for (int i = 1; i < 100; i++)
            {
                numbers.Add(new StartingNumber(i, int.Parse(evenExp), int.Parse(oddExp))); //TODO: error checking
            }

            //sort
            ViewBag.CurrentSort = sortOrder;
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

            int pageSize = 10; //UNDONE: items per page
            int pageNumber = page ?? 1;

            return View(orderedNumbers.ToPagedList(pageNumber, pageSize));
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