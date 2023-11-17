using Microsoft.AspNetCore.Mvc;
using real_estate.Data;
using real_estate.Models;
using System.Diagnostics;

namespace real_estate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult NewUser(Client client)
        {
            _context.client.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Signup");
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Edit(int id) { 
            var client_edit = _context.client.SingleOrDefault(x=>x.client_id == id); //search
            if (client_edit != null) {
                _context.client.Update(client_edit);

            }
            
            _context.SaveChanges();
            return View();
        }
        


        public IActionResult Index()
        {
            var user = _context.client.ToList();
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}