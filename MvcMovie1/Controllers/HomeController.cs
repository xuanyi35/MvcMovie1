using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using MvcMovie1.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MvcMovie1.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult MovieDetail()
        {
            ViewData["Message"] = "See more movie details";

            return View();
        }

      
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





    
        /// /////////////////////////////////////////////////////




        private readonly MvcMovie1Context _context;

        public HomeController(MvcMovie1Context context)
        {
            _context = context;
        }


        // POST: Movies/CreateFromApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MovieDetail(int mid, Movie movie)
        {



            if (TempData.Peek("UserId") == null)
            {
                return RedirectToAction("About", "Home"); 
            }
            else
            {

                //HtmlWeb page = new HtmlWeb();
                //HtmlDocument document = page.Load("http://localhost:50450/Home/MovieDetail");
  
                var client = new RestClient("https://api.themoviedb.org/3/movie/"+ mid + "?api_key=b7f9af2647fdef6d0633f07337802317");
                var request = new RestRequest(Method.GET);
                request.AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Dictionary<string, object> Mdetails = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);


                movie.Title = Convert.ToString(Mdetails["title"]);
                movie.ReleaseDate = Convert.ToDateTime(Mdetails["release_date"]);
                var genresList = (Mdetails["genres"] as IEnumerable).Cast<object>().Select(x => x.ToString()).ToArray();
                var temp = "";
                for (int i = 0;  i < genresList.Length; i++)
                {
                    Dictionary<string, object> genresdic = JsonConvert.DeserializeObject<Dictionary<string, object>>(genresList[i]);
                    //Trace.WriteLine("hhhhh " + genresdic["name"]);
                    temp = temp + genresdic["name"] + ";   ";
                }
                movie.Genre =  temp;
                movie.UserID = Convert.ToInt32(TempData.Peek("UserId"));
                movie.Homepage = Convert.ToString(Mdetails["homepage"]);
                
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");

            }

        }



        ///////////////////////////////////////////////////////////////////








    }
}
