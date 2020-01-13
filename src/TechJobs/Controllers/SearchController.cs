using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        // take 2 parameters (search type & search term) and pass into Views/Search/Index.cshtml
        // pass ListController.columnChoices to the view - reference Index method

        public IActionResult Results(string searchType, string searchTerm) 
        {

            // List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            // ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            // ViewBag.jobs = jobs;


            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            List<Dictionary<string, string>> jobList = new List<Dictionary<string, string>>();

            if (searchType.Equals("all"))
            {
                jobList = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobList;
                return View("search");
            }

            jobList = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.jobs = jobList;
            return View("search");
        }

    }

}
