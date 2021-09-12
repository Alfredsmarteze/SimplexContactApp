using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplexContactApp.Data;
using SimplexContactApp.Models;
using SimplexContactApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace SimplexContactApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactPersonServices _contactPersonService;
        private readonly ContactPersonContext _contactPersonContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IContactPersonServices contactPersonService, ContactPersonContext contactPersonContext)
        {
            _contactPersonService = contactPersonService;
            _contactPersonContext = contactPersonContext;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //Create a contact
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index( ContactModel contactModel)
        {
            
                if (ModelState.IsValid)
                {
                    await _contactPersonService.AddContact(contactModel);
                    ModelState.Clear();
                    ViewData["Message"] = "Contact Successfully Added.";
                    return View();
                }
                else if (!ModelState.IsValid)
                {

                    
                }
                return View();
            
        }

        //Get contact by Id
        [HttpGet]
        public  IActionResult EditContact(int? id)
        {

            //var retContactId =  _contactPersonService.GetContactId(id);
            var retContactId = _contactPersonContext.Contact.Find(id);
            if (retContactId==null)
            {
                return NotFound();
            }

           return View(retContactId);
            
        }

        //Update a contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContact(int id,  ContactModel contactModel )
        {
            //[Bind("Id,FirstName, LastName, PhoneNumber, Email, Address, Gender")]  This is optional but useful.

            if (id != contactModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               await _contactPersonService.UpdateContact(contactModel);
                
            }
          
            return View();
        }

        //Get contact to delete
        [HttpGet]
        public async Task<IActionResult> DeleteContact(int? id)
        {
            var contactDelete = _contactPersonContext.Contact.FirstOrDefault(s => s.Id == id);
            if (contactDelete == null)
            {
                return NotFound();
            }
            return View(contactDelete);

            
        }

        //Delete Contact
        [HttpPost,ActionName("DeleteContact")]
        public async Task<IActionResult> DeleteContactId(int id)
        {

            if (id==null)
            {
                return NotFound();
            }
            _contactPersonService.DeleteContacById(id);

            
            return View("DeleteContact");
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
