using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _247_Benchmark.Models;
using _247_Benchmark.Services.Business;
using _247_Benchmark.Services.Utility;

namespace _247_Benchmark.Controllers
{
    public class BibleController : Controller
    {
        private readonly ILogger logger;

        public BibleController(ILogger logger)
        {
            this.logger = logger;
        }

        // GET: Bible
        public ActionResult Index()
        {
            logger.Info("Entering BibleController.Index()");
            return View("AddVerse");
        }

        public ActionResult Search()
        {
            logger.Info("Entering BibleController.Search()");
            return View("Search");
        }

        [HttpPost]
        public ActionResult createVerse(BibleModel bible)
        {
            logger.Info("Entering BibleController.createVerse()");
            //checks if model is valid
            if (!ModelState.IsValid)
            {
                logger.Info("Model state is invalid");
                //if not, user is taken back to the add verse page
                return View("AddVerse");
            }

            else { 
                //call bible business service to add bible verse
                BibleBusinessService service = new BibleBusinessService();
                //user is taken to a success page once bible verse has been added
                if (service.addVerse(bible))
                {
                    logger.Info("Exiting BibleController.createVerse() with entry success");
                    return View("VerseSuccess");
                }
            }
            //if failed to add bible verse, user is taken back to the bible entry page
            logger.Info("Exiting BibleController.createVerse() with entry fail");
            return View("AddVerse");
        }

        [HttpPost]
        public ActionResult findVerse(SearchModel bible)
        {
            logger.Info("Entering BibleController.findVerse()");
            //checks if model is valid
              if (!ModelState.IsValid)
            {
                logger.Info("Model state is invalid");
                //if not, user is taken back to the search page
                return View("Search");
            }

            else
            {
                //call bible business service to find bible verse
                BibleBusinessService service = new BibleBusinessService();
                BibleModel result = service.findBibleVerse(bible);
                //user is taken to the search result page
                if (result != null)
                {
                    logger.Info("Exiting BibleController.createVerse() with search success");
                    return View("SearchResult", result);
                }
                logger.Info("Exiting BibleController.createVerse() with search fail");
                //if no verse was found, user is taken back to the search page
                return View("SearchResult");
            }
        }
    }
}