using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _247_Benchmark.Models;
using _247_Benchmark.Services.Data;

namespace _247_Benchmark.Services.Business
{
    public class BibleBusinessService
    {
        //method to add bible verse 
        public bool addVerse(BibleModel bible)
        {
            BibleDataService service = new BibleDataService();
            return service.addVerse(bible);
        }

        //method to find specific bible verse
        public BibleModel findBibleVerse(SearchModel bible)
        {
            BibleDataService service = new BibleDataService();
            return service.findBibleVerse(bible);
        }
    }
}