using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crispy.Models;
using crispy.ViewModels;

namespace crispy.Controllers
{
    public class MoviesController : Controller
    {


        // GET: Movies/random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "bob" };
            var customers = new List<Customer>
            {
                new Customer { Name =   "customer1"},
                new Customer { Name =   "customer2"}
            };


             var viewModel = new RandomMovieViewModel
             {
             Movie = movie,
             Customers = customers

             };
          //  var viewResult = new ViewResult();
           // viewResult.ViewData.Model;

            // return new ViewResult();
            return View(viewModel);// both works
        }




        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // GET: Movies/ByReleaseDate

        //attribute routing
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}" )]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" +month);
        }

        // GET: Movies/Index
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }

}
