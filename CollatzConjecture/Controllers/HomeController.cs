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
            IList<CollatzSequence> collatzSequences = new List<CollatzSequence>();
            for (int i = 1; i < 100; i++)
            {
                collatzSequences.Add(new CollatzSequence(i, int.Parse(evenExp), int.Parse(oddExp))); //TODO: parse error checking
            }

            //sort
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TheNumSortParm = string.IsNullOrEmpty(sortOrder) ? "thenum_desc" : "";
            ViewBag.NumStepsSortParm = sortOrder == "numsteps" ? "numsteps_desc" : "numsteps";

            IOrderedEnumerable<CollatzSequence> orderedCollatzSequences;
            switch (sortOrder)
            {
                case "thenum_desc":
                    orderedCollatzSequences = collatzSequences.OrderByDescending(cs => cs.InitialValue);
                    break;
                case "numsteps":
                    orderedCollatzSequences = collatzSequences.OrderBy(cs => cs.TotalStoppingTime); //TODO: use property
                    break;
                case "numsteps_desc":
                    orderedCollatzSequences = collatzSequences.OrderByDescending(cs => cs.TotalStoppingTime);
                    break;
                default:
                    orderedCollatzSequences = collatzSequences.OrderBy(cs => cs.InitialValue);
                    break;
            }

            int pageSize = 10; //UNDONE: items per page
            int pageNumber = page ?? 1;

            return View(orderedCollatzSequences.ToPagedList(pageNumber, pageSize));
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