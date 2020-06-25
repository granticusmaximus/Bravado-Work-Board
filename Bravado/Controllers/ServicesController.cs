using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bravado.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Bravado.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private AppDbContext _context;


        public ServicesController(AppDbContext context)
        {
            _context = context;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var Services = _context.ServiceEntity.ToList();
            return View(Services);
        }
    }
}
